﻿namespace TraktApiSharp.Objects.Basic.Json.Factories
{
    using Objects.Basic.Json.Reader;
    using Objects.Basic.Json.Writer;
    using Objects.Json;

    internal class CommentItemJsonIOFactory : IJsonIOFactory<ITraktCommentItem>
    {
        public IObjectJsonReader<ITraktCommentItem> CreateObjectReader() => new CommentItemObjectJsonReader();

        public IArrayJsonReader<ITraktCommentItem> CreateArrayReader() => new CommentItemArrayJsonReader();

        public IObjectJsonWriter<ITraktCommentItem> CreateObjectWriter() => new CommentItemObjectJsonWriter();
    }
}
