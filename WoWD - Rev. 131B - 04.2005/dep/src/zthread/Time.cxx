/*
 *  ZThreads, a platform-independent, multi threading and 
 *  synchronization library
 *
 *  Copyright (C) 2000-2003 Eric Crahen, See LGPL.TXT for details
 *
 *  This library is free software; you can redistribute it and/or
 *  modify it under the terms of the GNU Lesser General Public
 *  License as published by the Free Software Foundation; either
 *  version 2.1 of the License, or (at your option) any later version.
 *
 *  This library is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 *  Lesser General Public License for more details.
 *
 *  You should have received a copy of the GNU Lesser General Public
 *  License along with this library; if not, write to the Free Software
 *  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307 USA
 */

#include "zthread/Time.h"
#include "TimeStrategy.h"


using namespace ZThread;

Time::Time() {
  
  // System startup time
  static TimeStrategy firstHelper;
  TimeStrategy helper;

  Time then(firstHelper.seconds(), firstHelper.milliseconds());
  Time now(helper.seconds(), helper.milliseconds());

  now -= then;

  _seconds = now.seconds(); 
  _milliseconds = now.milliseconds();

}


