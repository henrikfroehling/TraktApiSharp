﻿namespace TraktApiSharp.Objects.Basic.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CrewObjectJsonWriter : AObjectJsonWriter<ITraktCrew>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktCrew obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            var crewMemberArrayJsonWriter = new ArrayJsonWriter<ITraktCrewMember>();
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Production != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.CREW_PROPERTY_NAME_PRODUCTION, cancellationToken).ConfigureAwait(false);
                await crewMemberArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Production, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Art != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.CREW_PROPERTY_NAME_ART, cancellationToken).ConfigureAwait(false);
                await crewMemberArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Art, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Crew != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.CREW_PROPERTY_NAME_CREW, cancellationToken).ConfigureAwait(false);
                await crewMemberArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Crew, cancellationToken).ConfigureAwait(false);
            }

            if (obj.CostumeAndMakeup != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.CREW_PROPERTY_NAME_COSTUME_AND_MAKE_UP, cancellationToken).ConfigureAwait(false);
                await crewMemberArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.CostumeAndMakeup, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Directing != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.CREW_PROPERTY_NAME_DIRECTING, cancellationToken).ConfigureAwait(false);
                await crewMemberArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Directing, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Writing != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.CREW_PROPERTY_NAME_WRITING, cancellationToken).ConfigureAwait(false);
                await crewMemberArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Writing, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Sound != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.CREW_PROPERTY_NAME_SOUND, cancellationToken).ConfigureAwait(false);
                await crewMemberArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Sound, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Camera != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.CREW_PROPERTY_NAME_CAMERA, cancellationToken).ConfigureAwait(false);
                await crewMemberArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Camera, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Lighting != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.CREW_PROPERTY_NAME_LIGHTING, cancellationToken).ConfigureAwait(false);
                await crewMemberArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Lighting, cancellationToken).ConfigureAwait(false);
            }

            if (obj.VisualEffects != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.CREW_PROPERTY_NAME_VISUAL_EFFECTS, cancellationToken).ConfigureAwait(false);
                await crewMemberArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.VisualEffects, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Editing != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.CREW_PROPERTY_NAME_EDITING, cancellationToken).ConfigureAwait(false);
                await crewMemberArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Editing, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
