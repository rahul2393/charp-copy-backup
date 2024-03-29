﻿// Copyright 2022 Google Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Google.Api.Gax;
using Google.Cloud.Spanner.Admin.Database.V1;
using Google.Protobuf.WellKnownTypes;
using System;

public class CopyBackupSample
{
    public void CopyBackup(string sourceInstanceId, string sourceProjectId, string sourceBackupId, string targetInstanceId, string targetProjectId, string targetBackupId, DateTimeOffset expireTime, DateTimeOffset maxExpireTime)
    {
        DatabaseAdminClient databaseAdminClient = new DatabaseAdminClientBuilder().Build();

        var request = new CopyBackupRequest
        {
            SourceBackupAsBackupName = new BackupName(sourceProjectId, sourceInstanceId, sourceBackupId),
            BackupId = targetBackupId,
            Parent = "projects/" + targetProjectId + "/instances/" + targetInstanceId,
            ExpireTime = (expireTime <= maxExpireTime) ? Timestamp.FromDateTimeOffset(expireTime) : Timestamp.FromDateTimeOffset(maxExpireTime)
        };

        var response = databaseAdminClient.CopyBackup(request);
        Console.WriteLine("Waiting for the operation to finish.");
        var completedResponse = response.PollUntilCompleted(new PollSettings(Expiration.FromTimeout(TimeSpan.FromMinutes(15)), TimeSpan.FromMinutes(2)));

        if (completedResponse.IsFaulted)
        {
            Console.WriteLine($"Error while creating backup: {completedResponse.Exception}");
            throw completedResponse.Exception;
        }

        BackupName backupName = BackupName.FromProjectInstanceBackup(targetProjectId, targetInstanceId, targetBackupId);
        Backup backup = databaseAdminClient.GetBackup(backupName);

        Console.WriteLine($"Backup created successfully.");
        Console.WriteLine($"Backup with Id {sourceBackupId} has been copied from {sourceProjectId}/{sourceInstanceId} to {targetProjectId}/{targetInstanceId} Backup {targetBackupId}"); 
        Console.WriteLine($"Backup {backup.Name} of size {backup.SizeBytes} bytes was created at {backup.CreateTime} from {backup.Database} and is in state {backup.State} and has version time {backup.VersionTime.ToDateTime()}");
    }
}

