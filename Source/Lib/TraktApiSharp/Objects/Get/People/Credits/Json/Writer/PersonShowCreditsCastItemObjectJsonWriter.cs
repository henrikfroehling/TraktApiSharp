﻿namespace TraktApiSharp.Objects.Get.People.Credits.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using Shows.Json.Writer;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PersonShowCreditsCastItemObjectJsonWriter : AObjectJsonWriter<ITraktPersonShowCreditsCastItem>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktPersonShowCreditsCastItem obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (!string.IsNullOrEmpty(obj.Character))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PERSON_SHOW_CREDITS_CAST_ITEM_PROPERTY_NAME_CHARACTER, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Character, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Show != null)
            {
                var movieObjectJsonWriter = new ShowObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PERSON_SHOW_CREDITS_CAST_ITEM_PROPERTY_NAME_SHOW, cancellationToken).ConfigureAwait(false);
                await movieObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Show, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
