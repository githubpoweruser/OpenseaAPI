using OpenseaAPI.Business.Interface;
using OpenseaAPI.DataAccess.Models;
using OpenseaAPI.DataAccess.MyDbContext;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenseaAPI.Business
{
    public class TestLogic : ITestLogic
    {
        private readonly OracleDbContext _dbContext;

        public TestLogic(OracleDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Test> Test1()
        {
            try
            {
                return _dbContext.Test.ToList(); ;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
