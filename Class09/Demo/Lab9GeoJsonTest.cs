using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Xunit;

namespace Demo
{
    public class Lab9GeoJsonTest
    {
        [Fact]
        public void Can_read_file()
        {
            // Arrange
            string filename = "data.json";
            string data = File.ReadAllText(filename);

            Assert.NotEmpty(data);

            // Act
            RootObject geojson = JsonConvert.DeserializeObject<RootObject>(data);

            // Assert
            Assert.NotNull(geojson);

            Assert.Equal("10001", geojson.features.First().properties.zip);
            Assert.NotEmpty(
                geojson.features
                    .Select(feature => feature.properties.zip)
                    .Distinct()
                );

            Assert.Equal(147, geojson.features.Count());
        }
    }
}
