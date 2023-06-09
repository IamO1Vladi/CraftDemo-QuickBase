using CraftDemo;
using System.Net;
using Moq;

namespace CraftDemoTests
{
    public class Tests
    {

            [Test]
            public void Constructor_WithValidParameters_For_FreshDesk_Contact()
            {
                // Arrange
                string name = "Vladimir VLadimirov";
                string email = "kiril_vladi@abv.bg";
                string twitterId = "c9vladi";
                int uniqueExternalId = 2001;
                string address = "Maksim Gorki";
                string description = "Unit test desc";

                // Act
                var contact = new FreshDeskContact(name, email, twitterId, uniqueExternalId, address, description);

                // Assert
                Assert.AreEqual(name, contact.Name);
                Assert.AreEqual(email, contact.Email);
                Assert.AreEqual(twitterId, contact.TwitterId);
                Assert.AreEqual(uniqueExternalId, contact.UniqueExternalId);
                Assert.AreEqual(address, contact.Address);
                Assert.AreEqual(description, contact.Description);
            }

        [Test]
        public void Constructor_WithValidArguments_For_GitHubUser()
        {
            // Arrange
            string username = "C9VLadi";
            int id = 2001;
            string nodeId = "nodeidtest";
            string gravatarId = "gravataridtest";
            string htmlUrl = "https://github.com/C9VLadi";
            string type = "User";
            bool siteAdmin = false;
            string name = "Vladimir VLadimirov";
            string company = "Quickbase";
            string blog = "test_blog";
            string location = "Pernik, Bulgaria";
            string email = "kiril_vladi@abv.bg";
            string hireable = "false";
            string bio = "Vivere militare est";
            string twitterUsername = "c9vladi";
            int publicRepos = 10;
            int publicGists = 5;
            int followers = 100;
            int following = 100;
            DateTime createdAt = DateTime.Now.AddDays(-7);
            DateTime updatedAt = DateTime.Now;
            string avatarUrl = "testavatarurl";

            // Act
            var user = new GitHubUser(
                username, id, nodeId, gravatarId, htmlUrl, type, siteAdmin, name, company, blog, location, email,
                hireable, bio, twitterUsername, publicRepos, publicGists, followers, following, createdAt, updatedAt, avatarUrl
            );

            // Assert
            Assert.AreEqual(username, user.UserName);
            Assert.AreEqual(id, user.Id);
            Assert.AreEqual(nodeId, user.NodeId);
            Assert.AreEqual(gravatarId, user.GravatarId);
            Assert.AreEqual(htmlUrl, user.HtmlUrl);
            Assert.AreEqual(type, user.Type);
            Assert.AreEqual(siteAdmin, user.SiteAdmin);
            Assert.AreEqual(name, user.Name);
            Assert.AreEqual(company, user.Company);
            Assert.AreEqual(blog, user.Blog);
            Assert.AreEqual(location, user.Location);
            Assert.AreEqual(email, user.Email);
            Assert.AreEqual(hireable, user.Hireable);
            Assert.AreEqual(bio, user.Bio);
            Assert.AreEqual(twitterUsername, user.TwitterUsername);
            Assert.AreEqual(publicRepos, user.PublicRepos);
            Assert.AreEqual(publicGists, user.PublicGists);
            Assert.AreEqual(followers, user.Followers);
            Assert.AreEqual(following, user.Following);
            Assert.AreEqual(createdAt, user.CreatedAt);
            Assert.AreEqual(updatedAt, user.LastUpdatedAt);
            Assert.AreEqual(avatarUrl, user.AvatarUrl);
        }

        [Test]
        public void Constructor_WithInvalidArguments_ThrowsException_For_GitHubUser()
        {
            // Arrange & Act & Assert
            //Username cannot be null
            Assert.Throws<ArgumentNullException>(() => new GitHubUser(null, 123, "node123", "gravatar123", "https://github.com/C9VLadi", "User", false, "Vladimir Vladimirov", "Quickbase", "testblog", "Pernik", "kiril_vladi@abv.bg", "false", "vivere militare est", "c9vladi", 10, 5, 100, 50, DateTime.Now.AddDays(-3), DateTime.Now, "testavatar"));
            //nodeid cannot be null
            Assert.Throws<ArgumentNullException>(() => new GitHubUser("C9Vladi", 123, null, "gravatar123", "https://github.com/C9VLadi", "User", false, "Vladimir Vladimirov", "Quickbase.", "testblog", "Pernik", "kiril_vladi@abv.bg", "false", "vivere militare est", "c9vladi", 10, 5, 100, 50, DateTime.Now.AddDays(-3), DateTime.Now, "testavatar"));
            // html url cannot be null
            Assert.Throws<ArgumentNullException>(() => new GitHubUser("C9VLadi", 123, "node123", null,null, "User", false, "Vladimir Vladimirov", "Quickbase", "testblog", "Pernik", "kiril_vladi@abv.bg", "false", "vivere militare est", "c9vladi", 10, 5, 100, 50, DateTime.Now.AddDays(-3), DateTime.Now, "testavatar"));
            // name cannot be null
            Assert.Throws<ArgumentNullException>(() => new GitHubUser("C9VLadi", 123, "node123", null, "test", "User", false, null, "Quickbase", "testblog", "Pernik", "kiril_vladi@abv.bg", "false", "vivere militare est", "c9vladi", 10, 5, 100, 50, DateTime.Now.AddDays(-3), DateTime.Now, "testavatar"));
            //followers cannot be a negative number
            Assert.Throws<ArgumentOutOfRangeException>(() => new GitHubUser("C9VLadi", 123, "node123", null, "test", "User", false, "Vladimir Vladimirov", "Quickbase", "testblog", "Pernik", "kiril_vladi@abv.bg", "false", "vivere militare est", "c9vladi", 10, 5, -100, 50, DateTime.Now.AddDays(-3), DateTime.Now, "testavatar"));
            //following cannot be a negative number
            Assert.Throws<ArgumentOutOfRangeException>(() => new GitHubUser("C9VLadi", 123, "node123", null, "test", "User", false, "Vladimir Vladimirov", "Quickbase", "testblog", "Pernik", "kiril_vladi@abv.bg", "false", "vivere militare est", "c9vladi", 10, 5, 100, -50, DateTime.Now.AddDays(-3), DateTime.Now, "testavatar"));
            //public repos cannot be a negative number
            Assert.Throws<ArgumentOutOfRangeException>(() => new GitHubUser("C9VLadi", 123, "node123", null, "test", "User", false, "Vladimir Vladimirov", "Quickbase", "testblog", "Pernik", "kiril_vladi@abv.bg", "false", "vivere militare est", "c9vladi", -10, 5, 100, 50, DateTime.Now.AddDays(-3), DateTime.Now, "testavatar"));
            //public gist cannot be a negative number
            Assert.Throws<ArgumentOutOfRangeException>(() => new GitHubUser("C9VLadi", 123, "node123", null, "test", "User", false, "Vladimir Vladimirov", "Quickbase", "testblog", "Pernik", "kiril_vladi@abv.bg", "false", "vivere militare est", "c9vladi", 10, -5, 100, 50, DateTime.Now.AddDays(-3), DateTime.Now, "testavatar"));
            //Updated at cannot be before created at
            Assert.Throws<ArgumentOutOfRangeException>(() => new GitHubUser("C9VLadi", 123, "node123", null, "test", "User", false, "Vladimir Vladimirov", "Quickbase", "testblog", "Pernik", "kiril_vladi@abv.bg", "false", "vivere militare est", "c9vladi", 10, 5, 100, 50, DateTime.Now.AddDays(-3), DateTime.Now.AddDays(-8), "testavatar"));
        }


        [Test]
        public void CreateFreshDeskJson_WithValidContact_ReturnsJsonString()
        {
            // Arrange
            var contact = new FreshDeskContact(
                "Vladimir Vladimirov", "kiril_vladi@abv.bg", "c9vladi", 2001, "Maksim Gorki", "Unit test desc");

            string expectedJson = "{\"name\":\"Vladimir Vladimirov\",\"email\":\"kiril_vladi@abv.bg\",\"twitter_id\":\"c9vladi\",\"unique_external_id\":2001,\"address\":\"Maksim Gorki\",\"description\":\"Unit test desc\",\"id\":0}";

            // Act
            string result = StartUp.CreateFreshDeskJson(contact);

            // Assert
            Assert.AreEqual(expectedJson, result);
        }

        [Test]
        public void CreateFreshDeskUser_FromGitHubUser_ReturnsFreshDeskContact()
        {
            // Arrange
            
            string username = "C9VLadi";
            int id = 2001;
            string nodeId = "nodeidtest";
            string gravatarId = "gravataridtest";
            string htmlUrl = "https://github.com/C9VLadi";
            string type = "User";
            bool siteAdmin = false;
            string name = "Vladimir VLadimirov";
            string company = "Quickbase";
            string blog = "test_blog";
            string location = "Pernik, Bulgaria";
            string email = "kiril_vladi@abv.bg";
            string hireable = "false";
            string bio = "Vivere militare est";
            string twitterUsername = "c9vladi";
            int publicRepos = 10;
            int publicGists = 5;
            int followers = 100;
            int following = 100;
            DateTime createdAt = DateTime.Now.AddDays(-7);
            DateTime updatedAt = DateTime.Now;
            string avatarUrl = "testavatarurl";

            // Act
            var gitHubUser = new GitHubUser(
                username, id, nodeId, gravatarId, htmlUrl, type, siteAdmin, name, company, blog, location, email,
                hireable, bio, twitterUsername, publicRepos, publicGists, followers, following, createdAt, updatedAt, avatarUrl
            );

            var expectedFreshDeskUser = new FreshDeskContact(
                gitHubUser.UserName, gitHubUser.Email, gitHubUser.TwitterUsername,
                gitHubUser.Id, gitHubUser.Location, gitHubUser.Bio);

            // Act
            var result = StartUp.CreateLocalFreshDeskContact(gitHubUser);

            // Assert
            Assert.AreEqual(expectedFreshDeskUser.Name, result.Name);
            Assert.AreEqual(expectedFreshDeskUser.Email, result.Email);
            Assert.AreEqual(expectedFreshDeskUser.TwitterId, result.TwitterId);
            Assert.AreEqual(expectedFreshDeskUser.UniqueExternalId, result.UniqueExternalId);
            Assert.AreEqual(expectedFreshDeskUser.Address, result.Address);
            Assert.AreEqual(expectedFreshDeskUser.Description, result.Description);
        }

    }
}