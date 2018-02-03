using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilePartitioning
{
    class Program
    {

        static int Main(string[] args)
        {
            string sourcePath = args[0];
            destFolderPath folders = new destFolderPath();

            for (int i = 1; i < 9; i++)
            {
                if (i == 1)
                {
                    folders.destPath1 = sourcePath + i;
                }
                else if (i == 2)
                {
                    folders.destPath2 = sourcePath + i;
                }
                else if (i == 3)
                {
                    folders.destPath3 = sourcePath + i;
                }
                else if (i == 4)
                {
                    folders.destPath4 = sourcePath + i;
                }
                else if (i == 5)
                {
                    folders.destPath5 = sourcePath + i;
                }
                else if (i == 6)
                {
                    folders.destPath6 = sourcePath + i;

                }
                else if (i == 7)
                {
                    folders.destPath7 = sourcePath + i;
                }
                else if (i == 8)
                {
                    folders.destPath8 = sourcePath + i;
                }

            }

            string pathnew_TYPE1 = sourcePath + "\\TYPE1";
            string pathnew_TYPE2 = sourcePath + "\\TYPE2";
            if (Directory.Exists(pathnew_TYPE1) || Directory.Exists(pathnew_TYPE2))
            {
                Directory.Delete(pathnew_TYPE1, true);
                Directory.Delete(pathnew_TYPE2, true);
            }

            string[] fileArrayTYPE1First = Directory.GetFiles(sourcePath, "*TYPE1*.xml", SearchOption.AllDirectories);
            string[] fileArrayTYPE2First = Directory.GetFiles(sourcePath, "*TYPE2*.xml", SearchOption.AllDirectories);
            int a = MoveFile(sourcePath, folders.destPath1, folders.destPath2, folders.destPath3, folders.destPath4, folders.destPath5, folders.destPath6, folders.destPath7, folders.destPath8, pathnew_TYPE1, fileArrayTYPE1First);
            int b = MoveFile(sourcePath, folders.destPath1, folders.destPath2, folders.destPath3, folders.destPath4, folders.destPath5, folders.destPath6, folders.destPath7, folders.destPath8, pathnew_TYPE2, fileArrayTYPE2First);
            int c = MoveFileBasic(sourcePath, folders.destPath8);
            Directory.Delete(pathnew_TYPE1, true);
            Directory.Delete(pathnew_TYPE2, true);
            if (a==0 && b==0 && c==0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
            
        }

        private static int MoveFileBasic(string source, string dest)
        {
            try
            {
                var fileArray = Directory.GetFiles(source, "*.xml", SearchOption.AllDirectories).Where(name => !name.Contains("TYPE1") && !name.Contains("TYPE2"));
                foreach (var item in fileArray)
                {

                    File.Copy(item, dest + '\\' + item.Split('\\')[2]);
                }
                return 0;
            }
            catch (Exception)
            {

                return 1;
            }

        }

        private static int MoveFile(string path, string path2, string path3, string path4, string path5, string path6, string path7, string path8, string path9, string pathnew_TYPE1, string[] fileArrayTYPE1First)
        {
            int a = pathnew_TYPE1.IndexOf("TYPE1");
            try
            {
                //Dest Folder var mı yok mu diye bak. Varsa içini boşalt.
                for (int i = 1; i < 9; i++)
                {
                    string pathnew = path + i;
                    if (Directory.Exists(pathnew))
                    {
                        if (a != -1)
                        {
                            string[] fileArray = Directory.GetFiles(pathnew, "*.xml", SearchOption.AllDirectories);
                            foreach (var file in fileArray)
                            {
                                File.Delete(file);
                            }
                        }

                    }
                    else
                    {
                        Directory.CreateDirectory(pathnew);
                    }
                }

                // Move the files      

                if (!Directory.Exists(pathnew_TYPE1))
                {
                    Directory.CreateDirectory(pathnew_TYPE1);

                    foreach (var item in fileArrayTYPE1First)
                    {
                        File.Copy(item, pathnew_TYPE1 + '\\' + item.Split('\\')[2]);
                    }

                }

                else
                {
                    string[] fileArray = Directory.GetFiles(pathnew_TYPE1, "*.xml", SearchOption.AllDirectories);
                    foreach (var item in fileArray)
                    {
                        File.Delete(item);
                    }
                    foreach (var item in fileArrayTYPE1First)
                    {
                        File.Copy(item, pathnew_TYPE1 + '\\' + item.Split('\\')[2]);
                    }
                }

                string[] fileArrayTYPE1;
                if (a != -1)
                {
                    fileArrayTYPE1 = Directory.GetFiles(pathnew_TYPE1, "*TYPE1*.xml", SearchOption.AllDirectories);
                }
                else
                {
                    fileArrayTYPE1 = Directory.GetFiles(pathnew_TYPE1, "*TYPE2*.xml", SearchOption.AllDirectories);

                }
                float p1 = CalculateFolderSize(path2);
                float p2 = CalculateFolderSize(path3);
                float p3 = CalculateFolderSize(path4);
                float p4 = CalculateFolderSize(path5);
                float p5 = CalculateFolderSize(path6);
                float p6 = CalculateFolderSize(path7);
                float p7 = CalculateFolderSize(path8);
                float p8 = CalculateFolderSize(path8);

                float sourceSize = CalculateFolderSize(pathnew_TYPE1);

                foreach (var item in fileArrayTYPE1)
                {
                    if ((sourceSize / 8) > (CalculateFolderSize(path2) - p1))
                    {
                        File.Copy(item, path2 + '\\' + item.Split('\\')[3]);
                    }


                    else if ((sourceSize / 8) < (CalculateFolderSize(path2) - p1))
                    {
                        if ((sourceSize / 8) > (CalculateFolderSize(path3) - p2))
                        {
                            File.Copy(item, path3 + '\\' + item.Split('\\')[3]);
                        }

                        else if ((sourceSize / 8) < (CalculateFolderSize(path3) - p2))
                        {
                            if ((sourceSize / 8) > (CalculateFolderSize(path4) - p3))
                            {
                                File.Copy(item, path4 + '\\' + item.Split('\\')[3]);
                            }

                            else if ((sourceSize / 8) < (CalculateFolderSize(path4) - p3))
                            {
                                if ((sourceSize / 8) > (CalculateFolderSize(path5) - p4))
                                {
                                    File.Copy(item, path5 + '\\' + item.Split('\\')[3]);
                                }

                                else if ((sourceSize / 8) < (CalculateFolderSize(path5) - p4))
                                {
                                    if ((sourceSize / 8) > (CalculateFolderSize(path6) - p5))
                                    {
                                        File.Copy(item, path6 + '\\' + item.Split('\\')[3]);
                                    }

                                    else if ((sourceSize / 8) < (CalculateFolderSize(path6) - p5))
                                    {
                                        if ((sourceSize / 8) > (CalculateFolderSize(path7) - p6))
                                        {
                                            File.Copy(item, path7 + '\\' + item.Split('\\')[3]);
                                        }

                                        else if ((sourceSize / 8) < (CalculateFolderSize(path7) - p6))
                                        {
                                            if ((sourceSize / 8) > (CalculateFolderSize(path8) - p7))
                                            {
                                                File.Copy(item, path8 + '\\' + item.Split('\\')[3]);
                                            }

                                            else if ((sourceSize / 8) < (CalculateFolderSize(path8) - p7))
                                            {
                                                File.Copy(item, path9 + '\\' + item.Split('\\')[3]);
                                            }

                                        }
                                    }
                                }
                            }
                        }
                    }

                    // Console.WriteLine("{0} was moved to {1}.", item, path2);
                    
                }
            }
            catch (Exception)
            {
                //Console.WriteLine("The process failed: {0}", e.ToString());
                return 1;
            }
            return 0;

        }


        protected static float CalculateFolderSize(string folder)
        {
            float folderSize = 0.0f;
            try
            {
                //Checks if the path is valid or not
                if (!Directory.Exists(folder))
                    return folderSize;
                else
                {
                    try
                    {
                        foreach (string file in Directory.GetFiles(folder))
                        {
                            if (File.Exists(file))
                            {
                                FileInfo finfo = new FileInfo(file);
                                folderSize += finfo.Length;
                            }
                        }

                        foreach (string dir in Directory.GetDirectories(folder))
                            folderSize += CalculateFolderSize(dir);
                    }
                    catch (NotSupportedException e)
                    {
                        Console.WriteLine("Unable to calculate folder size: {0}", e.Message);
                    }
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine("Unable to calculate folder size: {0}", e.Message);
            }
            return folderSize;
        }
    }
}
