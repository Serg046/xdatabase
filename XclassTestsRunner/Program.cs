﻿/*
 * Copyright 2010-2014 Fuks Alexander. Contacts: kungfux2010@gmail.com
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 * 
 *   http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using NUnit.Core;
using NUnit.ConsoleRunner;

namespace XclassTestsRunner
{
    public class Program
    {
        [STAThread]
        public static int Main(string[] args)
        {
            InternalTrace.Initialize("nunit-console_%p.log", InternalTraceLevel.Default);
            return Runner.Main(args);
        }
    }
}