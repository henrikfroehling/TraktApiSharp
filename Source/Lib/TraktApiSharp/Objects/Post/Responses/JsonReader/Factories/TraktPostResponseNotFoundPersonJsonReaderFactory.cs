﻿namespace TraktApiSharp.Objects.Post.Responses.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktPostResponseNotFoundPersonJsonReaderFactory : ITraktJsonReaderFactory<ITraktPostResponseNotFoundPerson>
    {
        public ITraktObjectJsonReader<ITraktPostResponseNotFoundPerson> CreateObjectReader() => new TraktPostResponseNotFoundPersonObjectJsonReader();

        public ITraktArrayJsonReader<ITraktPostResponseNotFoundPerson> CreateArrayReader() => new TraktPostResponseNotFoundPersonArrayJsonReader();
    }
}
