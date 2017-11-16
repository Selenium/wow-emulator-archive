unit TimedQueue;

interface

uses

  Windows, AcedContainers, SysUtils, Classes, SyncObjs, DateUtils,
  AcedAlgorithm;

const
  DEFAULT_QUEUE_SLEEP_TIME = 100;

type

  TComparatorFunction = TCompareFunction;
  TConsumerFunction = procedure (obj: TObject);

  TTimedQueue = ^PTimedQueue;
  PTimedQueue = record
    list        : TIntegerList;
    table       : TIntegerHashtable;
    comparator  : TComparatorFunction;
    consumer    : TConsumerFunction;
  end;

  TTimedQueueManager = class
    private
      q         : TTimedQueue;
      lock      : TCriticalSection;

      function    SleepBy : longword;
      function    Pop : Pointer;

    public
      constructor Create(timed_queue : TTimedQueue);

      function    Insert(timeSpan : integer; obj : Pointer) : integer;
      procedure   Remove(uid : integer; obj : Pointer);

      procedure   Start;
  end;

  function TimeGet : longword;

  function PrepareTimedQueue : TTimedQueue;

var
  { хранит указатели на элементы общей очереди, для ускорения удаления
    если нужно будет ускорить, кажется, надо будет копать где-то тут,
    потому что потенциально это отжиратель памяти }
  all           : TIntegerHashtable;
  luid          : integer;

  manager       : TTimedQueueManager;

implementation

{ Local functions }

function GetLUID : integer;
begin
  inc(luid);
  Result := luid;
end;

function Process(Parameter : Pointer) : Integer;
var
  p_      : Pointer;
  p_q     : TPriorityQueue;
  p_o     : Pointer;
  sb      : integer;
begin
  while true do
  begin
    sb := manager.SleepBy;
    if sb > 0 then
    begin
      sleep(sb);
      continue;
    end;
    
    p_ := manager.Pop;
    if p_ <> nil then
    begin
      p_q := TPriorityQueue(p_);
      while p_q.Count > 0 do
      begin
        p_o := p_q.Pop;
        manager.q.consumer(p_o);
        manager.Remove(integer(p_o^), p_o);
      end;
    end;
  end;
end;

{TTimedQueueManager}

constructor TTimedQueueManager.Create(timed_queue: TTimedQueue);
begin
  q := timed_queue;
  lock := TCriticalSection.Create;
end;

function    TTimedQueueManager.Insert(timeSpan : integer; obj : Pointer) : integer;
var
  t   : longword;
  p   : TPriorityQueue;
  uid : integer;
begin
  t := TimeGet + longword(timeSpan);

  lock.Acquire;

    if q.table.Contains(t) then
    begin
      p := TPriorityQueue(q.table.Items[t]);
    end else begin
      p := TPriorityQueue.Create(q.comparator);
      q.table.Add(t, p);
      q.list.Add(t);
    end;

    p.Push(obj);
    uid := GetLUID;
    Result := uid;

    all.Add(uid, p);
  lock.Release;
end;

procedure   TTimedQueueManager.Remove(uid : integer; obj : Pointer);
begin
  lock.Acquire;

  all.Remove(uid);

  lock.Release;
end;

procedure   TTimedQueueManager.Start;
var
  tid : cardinal;
begin
  BeginThread(nil,
              0,
              Addr(Process),
              nil,
              0,
              tid);
end;

function TTimedQueueManager.SleepBy : longword;
var
  t1, t2 : longword;
begin
  t1 := TimeGet;
  lock.Acquire;

    if q.list.Count > 0 then
    begin
      t2 := q.list.ItemList[0];
      if (t2 < t1) then
      begin
        Result := 0;
      end else begin
        Result := t2 - t1;
      end;
    end else begin
      Result := DEFAULT_QUEUE_SLEEP_TIME;
    end;

  lock.Release;
end;

function TTimedQueueManager.Pop : Pointer;
var
  i : integer;
begin
  lock.Acquire;

    if q.list.Count > 0 then
    begin
      i := q.list.ItemList[0];
      Result := q.table.Items[i];

      q.table.Remove(i);
      q.list.RemoveAt(0);
    end else begin
      Result := nil;
    end;

  lock.Release;
end;

{ Misc functions }

function TimeGet : longword;
var
  t : TTimeStamp;
begin
  t := DateTimeToTimeStamp(Now);

  Result := longword(((t.Date - 732400) * 24 * 3600 * 1000) + t.Time);
end;

function PrepareTimedQueue : TTimedQueue;
var
  t : TTimedQueue;
begin
  new(t);
  t.table := TIntegerHashtable.Create;
  t.list := TIntegerList.Create;
  t.list.MaintainSorted := true;
  Result := t;
end;

initialization

  all := TIntegerHashtable.Create;
  luid := 0;

end.

