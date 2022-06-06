# .NET Cloud Spanner Quickstart

A sample that demonstrate how to call the
[Google Cloud Spanner API](https://cloud.google.com/spanner/docs/) from C#.

## Build and Run

1.  **Follow the set-up instructions in [the documentation](https://cloud.google.com/dotnet/docs/setup).**

2.  Enable APIs for your project.
    [Click here](https://console.cloud.google.com/flows/enableapi?apiid=spanner.googleapis.com&showconfirmation=true)
    to visit Cloud Platform Console and enable the Google Cloud Spanner API.

3.  Install the following nuget packages present in the folder "Nuget Packages":
	 Google.Cloud.Spanner.Common.V1
	 Google.Cloud.Spanner.Admin.Database.V1

4.  Edit `QuickStart\Program.cs`, and  
	- Replace "source_Project_id" with the id of the source project 
	- Replace "source_Instance_id" with the id of the source instance
	- Replace "source_backup" with the id of the source backup
	- Replace "target_Project_id" with the id of the target project 
	- Replace "target_Instance_id" with the id of the target instance
	- Replace "target_backupId" with the id of the target backup
	- Adjust the "expireTime" as required
	- Adjust the "maxExpireTime" as required

5. Authenticate using : gcloud auth application-default login --no-launch-browser


6. You can run the sample program from within the Visual Studio or the command line. For running from the command line, navigate to the project folder and use `dotnet run`.
