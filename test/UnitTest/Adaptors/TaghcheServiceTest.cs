using Moq;
using Moq.Protected;
using System.Net;
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
        var bookService = new BookService(httpClient, "https://get.taaghche.com");


        // Act
        var actualJson = await bookService.GetBookAsync(1);

        // Assert
        Assert.Equal(await content.ReadAsStringAsync(), actualJson);
    }
}
