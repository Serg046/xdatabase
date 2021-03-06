﻿/*
 * Copyright © Alexander Fuks 2017 <Alexander.V.Fuks@gmail.com>
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
using System.Data.Common;

namespace XDatabase.Core
{
    public abstract partial class XQuery
    {
        public int Update(string pSqlQuery, params XParameter[] args)
        {
            ClearError();
            try
            {
                if (!IsConnectionActive)
                {
                    OpenConnection();
                }
                using (var command = GetCommand())
                {
                    command.Connection = Connection;
                    command.CommandText = pSqlQuery;
                    command.CommandTimeout = Timeout;

                    if (args != null)
                    {
                        foreach (var arg in args)
                        {
                            var parameter = GetParameter(arg.ParameterName, arg.Value);
                            command.Parameters.Add(parameter);
                        }
                    }
                    return command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                RegisterError(ex.Message);
                return -1;
            }
            finally
            {
                CloseConnection();
            }
        }

        public int Delete(string pSqlQuery, params XParameter[] args)
        {
            return Update(pSqlQuery, args);
        }

        public int Insert(string pSqlQuery, params XParameter[] args)
        {
            return Update(pSqlQuery, args);
        }

        public int Create(string pSqlQuery, params XParameter[] args)
        {
            return Update(pSqlQuery, args);
        }
    }
}
