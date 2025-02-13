using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSharpToolProject
{
    public static partial class ToolFunctions
    {
        #region Normal Fundtion
        /// <summary>
        /// 當Dictionary的Key為Enum，且Value為List時可使用。
        /// 
        /// 使用範例：
        /// Dictionary<MyEnum, List<int>> myDict;
        /// InitDictionary(out myDict, () => new List<int>());
        /// 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="target"></param>
        /// <param name="defaultValueFactory"></param>
        public static void InitDictionary<TKey, TValue>(ref Dictionary<TKey, TValue> target,
                                                            Func<TValue> defaultValueFactory)
        {
            target = new Dictionary<TKey, TValue>();

            TKey[] enumValues = (TKey[])Enum.GetValues(typeof(TKey));

            foreach (TKey enumValue in enumValues)
            {
                // 使用 factory 方法來創建每個 TValue 的新實例
                target.Add(enumValue, defaultValueFactory());
            }
        }

        /// <summary>
        /// 當Dictionary的Key為Enum，且Value為Dictionary時可使用。
        /// 
        /// 使用範例：
        /// Dictionary<MyEnum, Dictionary<string, int>> myDict;
        /// InitDictionary(out myDict, () => new Dictionary<string, int>());
        /// 
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TSubKey"></typeparam>
        /// <typeparam name="TSubValue"></typeparam>
        /// <param name="target"></param>
        /// <param name="defaultValueFactory"></param>
        public static void InitDictionary<TKey, TSubKey, TSubValue>(out Dictionary<TKey, Dictionary<TSubKey, TSubValue>> target,
                                                                        Func<Dictionary<TSubKey, TSubValue>> defaultValueFactory)
        {
            target = new Dictionary<TKey, Dictionary<TSubKey, TSubValue>>();

            TKey[] enumValues = (TKey[])Enum.GetValues(typeof(TKey));

            foreach (TKey enumValue in enumValues)
            {
                // 每次呼叫 defaultValueFactory() 來生成新的字典實例
                target.Add(enumValue, defaultValueFactory());
            }
        }

        /// <summary>
        /// 當Dictionary的Key為Enum，且Value為任一實值型別時可使用。
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="target"></param>
        public static void InitDictionary<TKey, TValue>(out Dictionary<TKey, TValue> target)
        {
            target = new Dictionary<TKey, TValue>();

            string[] enumNames = Enum.GetNames(typeof(TKey));

            foreach (string element in enumNames)
            {
                TKey enumValue = (TKey)Enum.Parse(typeof(TKey), element);

                target.Add(enumValue, default(TValue));
            }
        }

        public static Dictionary<TKey, TValue> InitDictionary<TKey, TValue>()
        {
            Dictionary<TKey, TValue> target = new Dictionary<TKey, TValue>();

            string[] enumNames = Enum.GetNames(typeof(TKey));

            foreach (string element in enumNames)
            {
                TKey enumValue = (TKey)Enum.Parse(typeof(TKey), element);

                target.Add(enumValue, default(TValue));
            }

            return target;
        }

        public static Dictionary<TKey, TValue> InitDictionary2<TKey, TValue>() where TKey : Enum
        {
            Dictionary<TKey, TValue> target = new Dictionary<TKey, TValue>();

            foreach (TKey enumValue in Enum.GetValues(typeof(TKey)))
            {
                // 為 TValue 嘗試初始化
                TValue value = typeof(TValue).IsValueType || typeof(TValue).GetConstructor(Type.EmptyTypes) != null
                    ? Activator.CreateInstance<TValue>()
                    : default;

                target.Add(enumValue, value);
            }

            return target;
        }
        #endregion

        #region Path Function - File

        /// <summary>
        /// 輸入資料夾路徑，可得到資料夾內的檔案路徑。
        /// </summary>
        /// <param name="folderPath"></param>
        /// <param name="filePaths"></param>
        /// <param name="searchPattern"></param>
        public static void GetAllFilePath(string folderPath, out string[] filePaths, string searchPattern = "")
        {
            if (searchPattern == "")
            {
                filePaths = Directory.GetFiles(folderPath);
            }
            else
            {
                filePaths = Directory.GetFiles(folderPath, "*.jpg");
            }

        }

        /// <summary>
        /// 輸入一陣列，陣列中帶有多個檔案路徑，可得到檔案名稱。
        /// </summary>
        /// <param name="filePaths"></param>
        /// <param name="filesNames"></param>
        public static void GetAllFileName(string[] filePaths, out List<string> filesNames)
        {
            filesNames = new List<string>();
            filesNames.Clear();

            // 逐一處理每個資料夾路徑
            foreach (string filePath in filePaths)
            {
                // 檢查資料夾是否存在
                if (File.Exists(filePath))
                {
                    // 使用 Path.GetFileName 取得資料夾名稱
                    string Name = Path.GetFileNameWithoutExtension(filePath);
                    filesNames.Add(Name);
                }
            }
        }

        /// <summary>
        /// 輸入檔案路徑，可得到檔案名稱。
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetFileName(string filePath)
        {
            // 使用 Path.GetFileName 取得檔案名稱
            string Name = Path.GetFileNameWithoutExtension(filePath);

            // 回傳檔案名稱
            return Name;
        }

        #endregion

        #region Path Function - Folder

        /// <summary>
        /// 輸入資料夾路徑，可得到資料夾內的子資料夾路徑。
        /// </summary>
        /// <param name="mainFolderPath"></param>
        /// <param name="folderPaths"></param>
        public static void GetAllFolderPath(string mainFolderPath, out string[] folderPaths)
        {
            folderPaths = Directory.GetDirectories(mainFolderPath);
        }

        /// <summary>
        /// 輸入一陣列，陣列中帶有多個資料夾路徑，可得到資料夾名稱。
        /// </summary>
        /// <param name="folderPaths"></param>
        /// <param name="folderNames"></param>
        public static void GetAllFolderName(string[] folderPaths, out List<string> folderNames)
        {
            folderNames = new List<string>();
            folderNames.Clear();

            // 逐一處理每個資料夾路徑
            foreach (string folderPath in folderPaths)
            {
                // 檢查資料夾是否存在
                if (Directory.Exists(folderPath))
                {
                    // 使用 Path.GetFileName 取得資料夾名稱
                    string folderName = Path.GetFileName(folderPath.TrimEnd(Path.DirectorySeparatorChar));
                    folderNames.Add(folderName);
                }
            }
        }

        /// <summary>
        /// 輸入資料夾路徑，可得到資料夾名稱。
        /// </summary>
        /// <param name="folderPath"></param>
        /// <returns></returns>
        public static string GetFolderName(string folderPath)
        {
            // 使用 DirectoryInfo 取得資料夾資訊
            DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);

            // 回傳資料夾名稱
            return directoryInfo.Name;
        }

        #endregion

        #region Image Peocessing 圖像處理
        /// <summary>
        /// 依照輸入寬度與目標圖片路徑，調整圖片大小並依照輸入儲存路徑儲存
        /// </summary>
        /// <param name="inputImagePath"></param>
        /// <param name="outputImagePath"></param>
        /// <param name="targetWidth"></param>
        public static void ResizeByWidthAndSaveImage(string inputImagePath, string outputImagePath, int targetWidth)
        {
            // 從指定路徑載入圖片
            using (Image originalImage = Image.FromFile(inputImagePath))
            {
                // 取得圖片的原始寬度和高度
                int originalWidth = originalImage.Width;
                int originalHeight = originalImage.Height;

                // 計算等比例縮放後的高度
                float ratio = (float)targetWidth / originalWidth;
                int targetHeight = (int)(originalHeight * ratio);

                // 調整圖片大小
                using (Bitmap resizedImage = new Bitmap(originalImage, new Size(targetWidth, targetHeight)))
                {
                    // 保存調整後的圖片到指定路徑
                    resizedImage.Save(outputImagePath);
                }
            }
        }
        #endregion

        #region DateTime Function
        public static string GetNowTime_toDay
        {
            get
            {
                return DateTime.Now.ToString("yyyyMMdd");
            }
        }
        #endregion
    }
}
