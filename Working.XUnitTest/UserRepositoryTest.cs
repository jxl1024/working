using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using Working.Context;
using Working.Models.APIModel;
using Working.Repository;
using Xunit;

namespace Working.XUnitTest
{
    public class UserRepositoryTest
    {
        [Fact]
        public void Login_Default_Return()
        {
            // Arrange
            var _dbMock = new InMemoryDbContextFactory().GetDbContext();
            var _userRepository = new UserRepository(_dbMock);

            // Act
            var userRole = _userRepository.Login("admin", "123456");

            // Assert
            Assert.NotNull(userRole);
        }



        public class InMemoryDbContextFactory
        {
            public AppDbContext GetDbContext()
            {
                var options = new DbContextOptionsBuilder<AppDbContext>()
                                .UseInMemoryDatabase(databaseName: "InMemoryArticleDatabase")
                                .Options;
                var dbContext = new AppDbContext(options);

                dbContext.Users.Add(new Models.DBModels.User() 
                {
                  ID=Guid.NewGuid(),
                  UserName="admin",
                  Password="123456",
                  RoleID=Guid.Parse("5844D12E-A443-41FC-B95A-EFE5BFC5E668"),
                  Name="π‹¿Ì‘±"
                });

                dbContext.Roles.Add(new Models.DBModels.Role() 
                {
                    ID = Guid.Parse("5844D12E-A443-41FC-B95A-EFE5BFC5E668"),
                    RoleName="Leader"
                });

                dbContext.SaveChanges();
                return dbContext;
            }
        }
    }
}
