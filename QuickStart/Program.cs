/*
 * Copyright (c) 2022 Google Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not
 * use this file except in compliance with the License. You may obtain a copy of
 * the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
 * License for the specific language governing permissions and limitations under
 * the License.
 */

using System;

namespace GoogleCloudSamples.Spanner
{
    public class QuickStart
    {
        public static void Main(string[] args)
        {
			string source_Project_id= "source_Project_id";
			string source_Instance_id= "source_Instance_id";
			string source_backupId= "source_backupId";
            string target_Project_id = "target_Project_id";
            string target_Instance_id = "target_Instance_id";
            string target_backupId = "target_backupId";
             
            DateTimeOffset expireTime = DateTimeOffset.UtcNow.AddDays(7);
			DateTimeOffset maxExpireTime = DateTimeOffset.Now.AddDays(10);
			
            CopyBackupSample copyBackupSample = new CopyBackupSample();
            copyBackupSample.CopyBackup(source_Instance_id, source_Project_id, source_backupId, target_Instance_id,target_Project_id, target_backupId, expireTime, maxExpireTime);
        }
    }
}
