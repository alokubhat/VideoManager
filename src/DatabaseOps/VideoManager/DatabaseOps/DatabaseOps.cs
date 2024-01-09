using DatabaseOps.TableSpecs;
using Microsoft.EntityFrameworkCore;
using System;

namespace DatabaseOps
{
    public class DatabaseOps
    {
        private DbContextImpl _context;
        public DatabaseOps(DbContextImpl context)
        {
            _context = context;
        }
        /// <summary>
        /// GET
        /// </summary>0
        /// <returns></returns>
        public List<FileDetailsModel> GetFileDetails()
        {
            List<FileDetailsModel> response = new List<FileDetailsModel>();
            var fileDetails = _context.FileDetails.ToList();
            var versionDetails = _context.VersionDetails.ToList();
            fileDetails.ForEach(file =>
            {
                var curVersionDetails = versionDetails.Where(item => item.File.Id == file.Id).ToList();
                List<VersionDetailsModel> curVersionDetailsModel = new List<VersionDetailsModel>();
                curVersionDetails.ForEach(version => curVersionDetailsModel.Add(new VersionDetailsModel
                {
                    Id = version.Id,
                    File_Id = file.Id,
                    VersionNum = version.VersionNum,
                    FilePath = version.FilePath,
                    UploadedOn = version.UploadedOn,
                    ModifiedOn = version.ModifiedOn,
                    SizeInKB = version.SizeInKB,
                    TimeInSecs = version.TimeInSecs,
                    Comment = version.Comment
                }));
                response.Add(new FileDetailsModel()
                {
                    Id = file.Id,
                    FileName = file.FileName,
                    Description = file.Description,
                    Versions = curVersionDetailsModel
                });
            });
            return response;
        }
        public FileDetailsModel GetFileDetailById(int id)
        {
            var fileDetail = _context.FileDetails.Where(item => item.Id.Equals(id)).FirstOrDefault();
            var curVersionDetails = _context.VersionDetails.ToList().Where(item => item.File.Id == fileDetail.Id).ToList();
            List<VersionDetailsModel> curVersionDetailsModel = new List<VersionDetailsModel>();
            curVersionDetails.ForEach(version => curVersionDetailsModel.Add(new VersionDetailsModel
            {
                Id = version.Id,
                File_Id = fileDetail.Id,
                VersionNum = version.VersionNum,
                FilePath = version.FilePath,
                UploadedOn = version.UploadedOn,
                ModifiedOn = version.ModifiedOn,
                SizeInKB = version.SizeInKB,
                TimeInSecs = version.TimeInSecs,
                Comment = version.Comment
            }));
            return new FileDetailsModel()
            {
                Id = fileDetail.Id,
                FileName = fileDetail.FileName,
                Description = fileDetail.Description,
                Versions = curVersionDetailsModel
            };
        }
        /// <summary>
        /// It serves the POST/PUT/PATCH
        /// </summary>
        public void SaveNewFile(FileDetailsModel fileDetailsModel)
        {
            FileDetails dbFileDetails = new FileDetails()
            {
                Id = fileDetailsModel.Id,
                FileName = fileDetailsModel.FileName,
                Description = fileDetailsModel.Description
            };

            List<VersionDetails> dbVersionDetailsList = new List<VersionDetails>();
            fileDetailsModel.Versions.ToList().ForEach(
                item => dbVersionDetailsList.Add(new VersionDetails {
                    Id = item.Id,
                    VersionNum = item.VersionNum,
                    FilePath = item.FilePath,
                    UploadedOn = item.UploadedOn,
                    ModifiedOn = item.ModifiedOn,
                    SizeInKB = item.SizeInKB,
                    TimeInSecs = item.TimeInSecs,
                    Comment = item.Comment,
                    File = dbFileDetails
                })
            );

            _context.FileDetails.Add(dbFileDetails);
            _context.VersionDetails.AddRange(dbVersionDetailsList);

            _context.SaveChanges();
        }

        public void SaveNewVersion(VersionDetailsModel versionDetailsModel) 
        {
            var dbFileDetails = _context.FileDetails.Where(file => file.Id.Equals(versionDetailsModel.File_Id)).FirstOrDefault();

            VersionDetails dbVersionDetails = new VersionDetails
            {
                Id = versionDetailsModel.Id,
                VersionNum = versionDetailsModel.VersionNum,
                FilePath = versionDetailsModel.FilePath,
                UploadedOn = versionDetailsModel.UploadedOn,
                ModifiedOn = versionDetailsModel.ModifiedOn,
                SizeInKB = versionDetailsModel.SizeInKB,
                TimeInSecs = versionDetailsModel.TimeInSecs,
                Comment = versionDetailsModel.Comment,
                File = dbFileDetails
            };

            _context.VersionDetails.Add(dbVersionDetails);

            _context.SaveChanges();
        }

        public void UpdateVersion(VersionDetailsModel versionDetailsModel) 
        {
            _context.VersionDetails.Where(item => item.Id.Equals(versionDetailsModel.Id)).ToList().ForEach(item => 
            {
                item.Id = versionDetailsModel.Id;
                item.VersionNum = versionDetailsModel.VersionNum;
                item.FilePath = versionDetailsModel.FilePath;
                item.UploadedOn = versionDetailsModel.UploadedOn;
                item.ModifiedOn = versionDetailsModel.ModifiedOn;
                item.SizeInKB = versionDetailsModel.SizeInKB;
                item.TimeInSecs = versionDetailsModel.TimeInSecs;
                item.Comment = versionDetailsModel.Comment;
            });

            _context.SaveChanges();
        }

        /// <summary>
        /// DELETE
        /// </summary>
        /// <param name="id"></param>
        public void DeleteVersion(int id)
        {
            var version = _context.VersionDetails.Where(item => item.Id.Equals(id)).FirstOrDefault();
            if (version != null)
            {
                _context.VersionDetails.Remove(version);
                _context.SaveChanges();
            }
        }

        public void DeleteFile(int id)
        {
            var file = _context.FileDetails.Where(item => item.Id.Equals(id)).FirstOrDefault();
            var versions = _context.VersionDetails.Where(item => item.File.Id.Equals(id)).ToList();
            foreach (var curVersion in versions) 
            {
                _context.VersionDetails.Remove(curVersion);
            }
            if (versions.Count > 0) 
            {
                _context.SaveChanges();
            }

            if (file != null)
            {
                _context.FileDetails.Remove(file);
                _context.SaveChanges();
            }
        }
    }
}
