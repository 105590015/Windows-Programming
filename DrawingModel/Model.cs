using System.Collections.Generic;
using GoogleDriveUploader.GoogleDrive;
using System.IO;

namespace DrawingModel
{
    public class Model
    {
        public event ModelChangedEventHandler _modelChanged;
        public delegate void ModelChangedEventHandler();
        private ShapeFactory _shapeFactory = new ShapeFactory();
        private CommandManager _commandManager = new CommandManager();
        private GoogleDriveService _service;
        private string _path;
        private string _pathDetail;
        private bool _isPressed = false;
        private List<Shape> _shapes = new List<Shape>();
        private Shape _hint;
        private IState _state;
        const string FILE_NAME = "WindowsProgramingData.txt";
        const string SLASH = "/";
        const char COMMA = ',';
        const int TWO = 2;
        const int THREE = 3;
        const int FOUR = 4;
        public Model(string path, string pathDetail, string credentialPath, bool judge)
        {
            const string APPLICATION_NAME = "DrawAnywhere";
            const string CLIENT_SECRET_FILE_NAME = "clientSecret.json";
            _path = path;
            _pathDetail = pathDetail;
            if (judge)
                _service = new GoogleDriveService(APPLICATION_NAME, CLIENT_SECRET_FILE_NAME, credentialPath);
        }

        //取得CommandManager
        public CommandManager GetCommandManager()
        {
            return _commandManager;
        }

        //取得所有圖形列表
        public List<Shape> GetShapes()
        {
            return _shapes;
        }

        //設定圖形
        public void CreateShape(string shape)
        {
            _state = new DrawingState(this, _commandManager, _shapeFactory.CreateShape(shape));
        }

        //當鼠標點擊
        public void PressPointer(double locationX, double locationY)
        {
            if (locationX > 0 && locationY > 0)
            {
                _isPressed = true;
                _hint = _state.PressPointer(locationX, locationY);
            }
        }

        //鼠標移動
        public void MovePointer(double locationX, double locationY)
        {
            if (_isPressed)
                _hint = _state.MovePointer(locationX, locationY);
        }

        //放開滑鼠
        public void ReleasePointer(double locationX, double locationY)
        {
            if (_isPressed)
            {
                _state.ReleasePointer(locationX, locationY);
                _state = new PointerState(this, _commandManager, _shapes);
                _isPressed = false;
            }
        }

        //清除圖畫
        public void Clear()
        {
            _isPressed = false;
            _commandManager.Execute(new ClearCommand(this, _shapes));
        }

        //還原清除畫面
        public void UndoClear(List<Shape> shapes)
        {
            for (int i = 0; i < shapes.Count; i++)
                _shapes.Add(shapes[i]);
        }

        //畫圖
        public void Draw(IGraphics graphics)
        {
            graphics.ClearAll();
            foreach (Shape aShape in _shapes)
            {
                if (aShape != null)
                    aShape.Draw(graphics);
            } 
            if (_isPressed && _hint != null)
                _hint.Draw(graphics);
        }

        //加入圖案
        public void AddShape(Shape shape)
        {
            _shapes.Add(shape);
        }

        //刪除最新的圖案
        public void DeleteShape()
        {
            _shapes.RemoveAt(_shapes.Count - 1);
        }

        //更新圖案
        public void UpdateShape(Shape shape, int index)
        {
            _shapes[index] = shape;
            _hint = shape;
        }

        //清空圖案
        public void ClearShape()
        {
            _shapes.Clear();
            _hint = null;
        }

        //儲存圖片資訊
        public void SaveImage()
        {
            const string CONTENT_TYPE = "text/plain";
            EnterImageData();
            Google.Apis.Drive.v2.Data.File file = LoadGoogleDriveData();
            if (file != null)
                _service.UpdateFile(FILE_NAME, file.Id, CONTENT_TYPE);
            else
                _service.UploadFile(FILE_NAME, CONTENT_TYPE);
        }

        //讀取圖片資訊
        public void LoadImage()
        {
            _shapes.Clear();
            Google.Apis.Drive.v2.Data.File file = LoadGoogleDriveData();
            _service.DownloadFile(file, _path);
            _service.DownloadFile(file, _path + _pathDetail);
            List<string> data = ReadData(_path + _pathDetail, FILE_NAME);
            for (int i = 0; i < data.Count && data[i] != ""; i++)
            {
                string[] information = data[i].Split(COMMA);
                Shape shape = _shapeFactory.CreateShape(information[0]);
                shape.SetLocation(System.Convert.ToDouble(information[1]), System.Convert.ToDouble(information[TWO]), System.Convert.ToDouble(information[THREE]), System.Convert.ToDouble(information[FOUR]));
                _shapes.Add(shape);
            }
            _commandManager.Reset();
        }

        //讀取GoogleDrive資料
        public Google.Apis.Drive.v2.Data.File LoadGoogleDriveData()
        {
            const string QUERY = "'root' in parents";
            Google.Apis.Drive.v2.Data.File file = null;
            List<Google.Apis.Drive.v2.Data.File> returnList = _service.ListFileAndFolderWithQueryString(QUERY);
            for (int i = 0; i < returnList.Count; i++)
            {
                if (returnList[i].Title == FILE_NAME)
                    file = returnList[i];
            }
            return file;
        }

        //將圖案資料存進根目錄與/bin/debug裡的WindowsProgramingData.txt
        public void EnterImageData()
        {
            List<string> data = new List<string>();
            foreach (Shape aShape in _shapes)
                data.Add(aShape.GetInformation());
            EnterData(_path, FILE_NAME, data);
            EnterData(_path + _pathDetail, FILE_NAME, data);
        }

        //將資料存進文件檔
        public void EnterData(string path, string fileName, List<string> data)
        {
            using (FileStream fileStream = new FileStream(path + SLASH + fileName, FileMode.Open))
            {
                using (StreamWriter streamWrite = new StreamWriter(fileStream))
                {
                    foreach (string information in data)
                        streamWrite.WriteLine(information);
                }
            }
        }

        //讀取文件檔
        public List<string> ReadData(string path, string fileName)
        {
            List<string> data = new List<string>();
            using (FileStream fileStream = new FileStream(path + SLASH + fileName, FileMode.Open))
            {
                using (StreamReader streamReader = new StreamReader(fileStream))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                        data.Add(line);
                }
            }
            return data;
        }
    }
}
