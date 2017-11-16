namespace Server
{
    using Server.Guilds;
    using System;
    using System.Runtime.CompilerServices;

    public class EventSink
    {
        // Events
        public static  event AccountLoginEventHandler AccountLogin;
        public static  event AggressiveActionEventHandler AggressiveAction;
        public static  event AnimateRequestEventHandler AnimateRequest;
        public static  event CastSpellRequestEventHandler CastSpellRequest;
        public static  event ChangeProfileRequestEventHandler ChangeProfileRequest;
        public static  event CharacterCreatedEventHandler CharacterCreated;
        public static  event ChatRequestEventHandler ChatRequest;
        public static  event CommandEventHandler Command;
        public static  event ConnectedEventHandler Connected;
        public static  event CrashedEventHandler Crashed;
        public static  event CreateGuildHandler CreateGuild;
        public static  event DeleteRequestEventHandler DeleteRequest;
        public static  event DisarmRequestEventHandler DisarmRequest;
        public static  event DisconnectedEventHandler Disconnected;
        public static  event FastWalkEventHandler FastWalk;
        public static  event GameLoginEventHandler GameLogin;
        public static  event HelpRequestEventHandler HelpRequest;
        public static  event HungerChangedEventHandler HungerChanged;
        public static  event LoginEventHandler Login;
        public static  event LogoutEventHandler Logout;
        public static  event MovementEventHandler Movement;
        public static  event OpenDoorMacroEventHandler OpenDoorMacroUsed;
        public static  event OpenSpellbookRequestEventHandler OpenSpellbookRequest;
        public static  event PaperdollRequestEventHandler PaperdollRequest;
        public static  event PlayerDeathEventHandler PlayerDeath;
        public static  event ProfileRequestEventHandler ProfileRequest;
        public static  event RenameRequestEventHandler RenameRequest;
        public static  event ServerListEventHandler ServerList;
        public static  event ServerStartedEventHandler ServerStarted;
        public static  event SetAbilityEventHandler SetAbility;
        public static  event ShutdownEventHandler Shutdown;
        public static  event SpeechEventHandler Speech;
        public static  event StunRequestEventHandler StunRequest;
        public static  event VirtueGumpRequestEventHandler VirtueGumpRequest;
        public static  event VirtueItemRequestEventHandler VirtueItemRequest;
        public static  event WorldLoadEventHandler WorldLoad;
        public static  event WorldSaveEventHandler WorldSave;

        // Methods
        public EventSink()
        {
        }

        public static void InvokeAccountLogin(AccountLoginEventArgs e)
        {
            if (EventSink.AccountLogin != null)
            {
                EventSink.AccountLogin.Invoke(e);
            }
        }

        public static void InvokeAggressiveAction(AggressiveActionEventArgs e)
        {
            if (EventSink.AggressiveAction != null)
            {
                EventSink.AggressiveAction.Invoke(e);
            }
        }

        public static void InvokeAnimateRequest(AnimateRequestEventArgs e)
        {
            if (EventSink.AnimateRequest != null)
            {
                EventSink.AnimateRequest.Invoke(e);
            }
        }

        public static void InvokeCastSpellRequest(CastSpellRequestEventArgs e)
        {
            if (EventSink.CastSpellRequest != null)
            {
                EventSink.CastSpellRequest.Invoke(e);
            }
        }

        public static void InvokeChangeProfileRequest(ChangeProfileRequestEventArgs e)
        {
            if (EventSink.ChangeProfileRequest != null)
            {
                EventSink.ChangeProfileRequest.Invoke(e);
            }
        }

        public static void InvokeCharacterCreated(CharacterCreatedEventArgs e)
        {
            if (EventSink.CharacterCreated != null)
            {
                EventSink.CharacterCreated.Invoke(e);
            }
        }

        public static void InvokeChatRequest(ChatRequestEventArgs e)
        {
            if (EventSink.ChatRequest != null)
            {
                EventSink.ChatRequest.Invoke(e);
            }
        }

        public static void InvokeCommand(CommandEventArgs e)
        {
            if (EventSink.Command != null)
            {
                EventSink.Command.Invoke(e);
            }
        }

        public static void InvokeConnected(ConnectedEventArgs e)
        {
            if (EventSink.Connected != null)
            {
                EventSink.Connected.Invoke(e);
            }
        }

        public static void InvokeCrashed(CrashedEventArgs e)
        {
            if (EventSink.Crashed != null)
            {
                EventSink.Crashed.Invoke(e);
            }
        }

        public static BaseGuild InvokeCreateGuild(CreateGuildEventArgs e)
        {
            if (EventSink.CreateGuild != null)
            {
                return EventSink.CreateGuild.Invoke(e);
            }
            return null;
        }

        public static void InvokeDeleteRequest(DeleteRequestEventArgs e)
        {
            if (EventSink.DeleteRequest != null)
            {
                EventSink.DeleteRequest.Invoke(e);
            }
        }

        public static void InvokeDisarmRequest(DisarmRequestEventArgs e)
        {
            if (EventSink.DisarmRequest != null)
            {
                EventSink.DisarmRequest.Invoke(e);
            }
        }

        public static void InvokeDisconnected(DisconnectedEventArgs e)
        {
            if (EventSink.Disconnected != null)
            {
                EventSink.Disconnected.Invoke(e);
            }
        }

        public static void InvokeFastWalk(FastWalkEventArgs e)
        {
            if (EventSink.FastWalk != null)
            {
                EventSink.FastWalk.Invoke(e);
            }
        }

        public static void InvokeGameLogin(GameLoginEventArgs e)
        {
            if (EventSink.GameLogin != null)
            {
                EventSink.GameLogin.Invoke(e);
            }
        }

        public static void InvokeHelpRequest(HelpRequestEventArgs e)
        {
            if (EventSink.HelpRequest != null)
            {
                EventSink.HelpRequest.Invoke(e);
            }
        }

        public static void InvokeHungerChanged(HungerChangedEventArgs e)
        {
            if (EventSink.HungerChanged != null)
            {
                EventSink.HungerChanged.Invoke(e);
            }
        }

        public static void InvokeLogin(LoginEventArgs e)
        {
            if (EventSink.Login != null)
            {
                EventSink.Login.Invoke(e);
            }
        }

        public static void InvokeLogout(LogoutEventArgs e)
        {
            if (EventSink.Logout != null)
            {
                EventSink.Logout.Invoke(e);
            }
        }

        public static void InvokeMovement(MovementEventArgs e)
        {
            if (EventSink.Movement != null)
            {
                EventSink.Movement.Invoke(e);
            }
        }

        public static void InvokeOpenDoorMacroUsed(OpenDoorMacroEventArgs e)
        {
            if (EventSink.OpenDoorMacroUsed != null)
            {
                EventSink.OpenDoorMacroUsed.Invoke(e);
            }
        }

        public static void InvokeOpenSpellbookRequest(OpenSpellbookRequestEventArgs e)
        {
            if (EventSink.OpenSpellbookRequest != null)
            {
                EventSink.OpenSpellbookRequest.Invoke(e);
            }
        }

        public static void InvokePaperdollRequest(PaperdollRequestEventArgs e)
        {
            if (EventSink.PaperdollRequest != null)
            {
                EventSink.PaperdollRequest.Invoke(e);
            }
        }

        public static void InvokePlayerDeath(PlayerDeathEventArgs e)
        {
            if (EventSink.PlayerDeath != null)
            {
                EventSink.PlayerDeath.Invoke(e);
            }
        }

        public static void InvokeProfileRequest(ProfileRequestEventArgs e)
        {
            if (EventSink.ProfileRequest != null)
            {
                EventSink.ProfileRequest.Invoke(e);
            }
        }

        public static void InvokeRenameRequest(RenameRequestEventArgs e)
        {
            if (EventSink.RenameRequest != null)
            {
                EventSink.RenameRequest.Invoke(e);
            }
        }

        public static void InvokeServerList(ServerListEventArgs e)
        {
            if (EventSink.ServerList != null)
            {
                EventSink.ServerList.Invoke(e);
            }
        }

        public static void InvokeServerStarted()
        {
            if (EventSink.ServerStarted != null)
            {
                EventSink.ServerStarted.Invoke();
            }
        }

        public static void InvokeSetAbility(SetAbilityEventArgs e)
        {
            if (EventSink.SetAbility != null)
            {
                EventSink.SetAbility.Invoke(e);
            }
        }

        public static void InvokeShutdown(ShutdownEventArgs e)
        {
            if (EventSink.Shutdown != null)
            {
                EventSink.Shutdown.Invoke(e);
            }
        }

        public static void InvokeSpeech(SpeechEventArgs e)
        {
            if (EventSink.Speech != null)
            {
                EventSink.Speech.Invoke(e);
            }
        }

        public static void InvokeStunRequest(StunRequestEventArgs e)
        {
            if (EventSink.StunRequest != null)
            {
                EventSink.StunRequest.Invoke(e);
            }
        }

        public static void InvokeVirtueGumpRequest(VirtueGumpRequestEventArgs e)
        {
            if (EventSink.VirtueGumpRequest != null)
            {
                EventSink.VirtueGumpRequest.Invoke(e);
            }
        }

        public static void InvokeVirtueItemRequest(VirtueItemRequestEventArgs e)
        {
            if (EventSink.VirtueItemRequest != null)
            {
                EventSink.VirtueItemRequest.Invoke(e);
            }
        }

        public static void InvokeWorldLoad()
        {
            if (EventSink.WorldLoad != null)
            {
                EventSink.WorldLoad.Invoke();
            }
        }

        public static void InvokeWorldSave(WorldSaveEventArgs e)
        {
            if (EventSink.WorldSave != null)
            {
                EventSink.WorldSave.Invoke(e);
            }
        }

        public static void Reset()
        {
            EventSink.CharacterCreated = null;
            EventSink.OpenDoorMacroUsed = null;
            EventSink.Speech = null;
            EventSink.Login = null;
            EventSink.ServerList = null;
            EventSink.Movement = null;
            EventSink.HungerChanged = null;
            EventSink.Crashed = null;
            EventSink.Shutdown = null;
            EventSink.HelpRequest = null;
            EventSink.DisarmRequest = null;
            EventSink.StunRequest = null;
            EventSink.OpenSpellbookRequest = null;
            EventSink.CastSpellRequest = null;
            EventSink.AnimateRequest = null;
            EventSink.Logout = null;
            EventSink.Connected = null;
            EventSink.Disconnected = null;
            EventSink.RenameRequest = null;
            EventSink.PlayerDeath = null;
            EventSink.VirtueGumpRequest = null;
            EventSink.VirtueItemRequest = null;
            EventSink.ChatRequest = null;
            EventSink.AccountLogin = null;
            EventSink.PaperdollRequest = null;
            EventSink.ProfileRequest = null;
            EventSink.ChangeProfileRequest = null;
            EventSink.AggressiveAction = null;
            EventSink.Command = null;
            EventSink.GameLogin = null;
            EventSink.DeleteRequest = null;
            EventSink.WorldLoad = null;
            EventSink.WorldSave = null;
            EventSink.SetAbility = null;
        }

    }
}

