using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using System.Net;
using TaghcheCC.TaghcheServiceAdaptor;
using TaghcheServiceAdaptor;

namespace UnitTest.Adaptors;
public class TaghcheServiceTests
{
    private readonly Mock<HttpMessageHandler> mockHttpMessageHandler;
    public TaghcheServiceTests()
    {
        mockHttpMessageHandler = new Mock<HttpMessageHandler>();
    }
    [Fact]
    public async Task GetBookAsync_ReturnsJsonString_WhenSuccess()
    {
        // Arrange
        var content = new StringContent("{\"Id\": 1, \"Title\": \"Test Book\", \"Author\": \"John Doe\", \"YearPublished\": 2022}");
        var protect = mockHttpMessageHandler
            .Protected();
            protect.Setup<Task<HttpResponseMessage>>("SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = content
            });
        var httpClient = new HttpClient(mockHttpMessageHandler.Object);

        TaghcheSettings settings = new TaghcheSettings() 
        { 
            ApiVersion="/v2" , 
            BaseUrl= "https://get.taaghche.com",
            FetchBookEndpoint= "/book/{0}"

        };
                                                                                        // Make sure you include using Moq;
        var mockOption= new Mock<IOptions<TaghcheSettings>>();
        mockOption.Setup(ap => ap.Value).Returns(settings);

        var bookService = new TaghcheService(httpClient, mockOption.Object);


        // Act
        var actualJson = await bookService.GetBookAsync("1");

        // Assert
        Assert.Equal(await content.ReadAsStringAsync(), actualJson);
    }
}
