using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace MyChecker
{
    class FreeSpaceChecker:IChecker
    {
        private String _drivename;
        
        public FreeSpaceChecker(String DriveName)
        {
            _drivename = DriveName;
        }

        public CheckResult Check()
        {
            CheckResult Result = new CheckResult();
            Result.Message = String.Format("{0}\n Drive {1} free space is OK.",
                this.GetType().ToString() , _drivename);
            try
            {
                DriveInfo drive = new DriveInfo(_drivename);
                if (drive.IsReady)
                {
                    Double ratio = (double)100*drive.TotalFreeSpace / drive.TotalSize;
                    if (ratio < 10)
                    {
                        Result.Message = String.Format("{0}\n Drive {1} free space is low.\n Free:{2,15} \n Total:{3,15}",
                            this.GetType().ToString(), _drivename, drive.TotalFreeSpace, drive.TotalSize);
                        Result.Status = ResultStatus.ERR;
                    }

                }
                else
                {
                    Result.Message = String.Format("{0}\n Drive {1} is not ready.",
                        this.GetType().ToString(), _drivename);
                    Result.Status = ResultStatus.WARNING;
                }
            }
            catch (Exception ex)
            {
                Result.Message = String.Format("{0}\n Checking Drive {1} get an exception:{2}",
                           this.GetType().ToString() , _drivename , ex.Message);
                Result.Status = ResultStatus.WARNING;
            }


           return Result;
        }

    }
}
