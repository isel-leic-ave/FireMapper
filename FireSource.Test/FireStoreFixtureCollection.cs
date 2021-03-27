using Xunit;

namespace FireSource.Test
{
    [CollectionDefinition("FireStoreFixture collection")]
    public class FireStoreFixtureCollection : ICollectionFixture<FireStoreFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}