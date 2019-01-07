using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Google.Apis.Drive.v2;
using Google.Apis.Auth.OAuth2;
using System.IO;
using System.Threading;
using Google.Apis.Util.Store;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Download;
using Google.Apis.Drive.v2.Data;

namespace GoogleDriveUploader.GoogleDrive
{
    public class GoogleDriveService
    {
        private readonly string[] _scopes = new[] { DriveService.Scope.DriveFile, DriveService.Scope.Drive };
        private DriveService _service;
        private const int KB = 0x400;
        private const int DOWNLOAD_CHUNK_SIZE = 256 * KB;
        private int _timeStamp;
        private string _applicationName;
        private string _clientSecretFileName;
        private string _credentialPath;
        private UserCredential _credential;
        const int TWO = 2;
        const char SPLASH = '\\';
        public GoogleDriveService(string applicationName, string clientSecretFileName, string credentialPath)
        {
            _applicationName = applicationName;
            _clientSecretFileName = clientSecretFileName;
            _credentialPath = credentialPath;
            CreateNewService(applicationName, clientSecretFileName, credentialPath);
        }

        //建立服務
        private void CreateNewService(string applicationName, string clientSecretFileName, string credentialPath)
        {
            const string USER = "user";
            const string CREDENTIAL_FOLDER = ".credential/";
            UserCredential credential;
            using (FileStream stream = new FileStream(clientSecretFileName, FileMode.Open, FileAccess.Read))
            {
                credentialPath = Path.Combine(credentialPath, CREDENTIAL_FOLDER + applicationName);
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets, _scopes, USER, CancellationToken.None, new FileDataStore(credentialPath, true)).Result;
            }
            DriveService service = new DriveService(new BaseClientService.Initializer()
            { 
                HttpClientInitializer = credential,
                ApplicationName = applicationName });
            _credential = credential;
            DateTime now = DateTime.Now;
            _timeStamp = UNIXNowTimeStamp;
            _service = service;
        }

        //計算時間戳
        private int UNIXNowTimeStamp
        {
            get
            {
                const int UNIX_START_YEAR = 1970;
                DateTime unixStartTime = new DateTime(UNIX_START_YEAR, 1, 1);
                return Convert.ToInt32((DateTime.Now.Subtract(unixStartTime).TotalSeconds));
            }
        }

        //確認憑證，若憑證超時就刷新服務
        private void CheckCredentialTimeStamp()
        {
            const int ONE_HOUR_SECOND = 3600;
            int nowTimeStamp = UNIXNowTimeStamp;
            if ((nowTimeStamp - _timeStamp) > ONE_HOUR_SECOND)
                CreateNewService(_applicationName, _clientSecretFileName, _credentialPath);
        }

        // 使用QueryString查詢檔案，回傳List
        public List<Google.Apis.Drive.v2.Data.File> ListFileAndFolderWithQueryString(string queryString)
        {
            List<Google.Apis.Drive.v2.Data.File> returnList = new List<Google.Apis.Drive.v2.Data.File>();
            CheckCredentialTimeStamp();
            FilesResource.ListRequest listRequest = _service.Files.List();
            listRequest.Q = queryString;
            SearchGoogleDrive(returnList, listRequest);
            return returnList;
        }

        //搜尋GoogleDrive
        private void SearchGoogleDrive(List<Google.Apis.Drive.v2.Data.File> returnList, FilesResource.ListRequest listRequest)
        {
            do
            {
                try
                {
                    FileList fileList = listRequest.Execute();
                    returnList.AddRange(fileList.Items);
                    listRequest.PageToken = fileList.NextPageToken;
                }
                catch (Exception exception)
                {
                    listRequest.PageToken = null;
                    throw exception;
                }
            } while (!String.IsNullOrEmpty(listRequest.PageToken));
        }

        //上傳檔案
        public Google.Apis.Drive.v2.Data.File UploadFile(string uploadFileName, string contentType, Action<IUploadProgress> upload = null, Action<Google.Apis.Drive.v2.Data.File> responseReceivedEventHandler = null)
        {
            string title = "";
            FileStream uploadStream = new FileStream(uploadFileName, FileMode.Open, FileAccess.Read);
            CheckCredentialTimeStamp();
            if (uploadFileName.LastIndexOf(SPLASH) != -1)
                title = uploadFileName.Substring(uploadFileName.LastIndexOf(SPLASH) + 1);
            else
                title = uploadFileName;
            Google.Apis.Drive.v2.Data.File fileToInsert = new Google.Apis.Drive.v2.Data.File();
            fileToInsert.Title = title;
            FilesResource.InsertMediaUpload insertRequest = _service.Files.Insert(fileToInsert, uploadStream, contentType);
            insertRequest.ChunkSize = FilesResource.InsertMediaUpload.MinimumChunkSize * TWO;
            if (upload != null)
                insertRequest.ProgressChanged += upload;
            if (responseReceivedEventHandler != null)
                insertRequest.ResponseReceived += responseReceivedEventHandler;
            TryUpload(uploadStream, insertRequest);
            return insertRequest.ResponseBody;
        }

        //嘗試上傳
        public void TryUpload(FileStream uploadStream, FilesResource.InsertMediaUpload insertRequest)
        {
            try
            {
                insertRequest.Upload();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        //下載檔案
        public void DownloadFile(Google.Apis.Drive.v2.Data.File fileToDownload, string path, Action<IDownloadProgress> test = null)
        {
            const string SPLASH = @"\";
            CheckCredentialTimeStamp();
            if (!String.IsNullOrEmpty(fileToDownload.DownloadUrl))
            {
                try
                {
                    Task<byte[]> downloadByte = _service.HttpClient.GetByteArrayAsync(fileToDownload.DownloadUrl);
                    byte[] byteArray = downloadByte.Result;
                    string downloadPosition = path + SPLASH + fileToDownload.Title;
                    System.IO.File.WriteAllBytes(downloadPosition, byteArray);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
        }

        //更新指定FileID的檔案
        public Google.Apis.Drive.v2.Data.File UpdateFile(string fileName, string fileId, string contentType)
        {
            CheckCredentialTimeStamp();
            try
            {
                Google.Apis.Drive.v2.Data.File file = _service.Files.Get(fileId).Execute();
                byte[] byteArray = System.IO.File.ReadAllBytes(fileName);
                MemoryStream stream = new MemoryStream(byteArray);
                FilesResource.UpdateMediaUpload request = _service.Files.Update(file, fileId, stream, contentType);
                request.NewRevision = true;
                request.Upload();
                Google.Apis.Drive.v2.Data.File updatedFile = request.ResponseBody;
                return updatedFile;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
