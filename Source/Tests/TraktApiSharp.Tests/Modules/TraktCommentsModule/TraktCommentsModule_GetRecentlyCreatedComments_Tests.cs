﻿namespace TraktApiSharp.Tests.Modules.TraktCommentsModule
{
    using FluentAssertions;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Exceptions;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Requests.Parameters;
    using TraktApiSharp.Responses;
    using Xunit;

    [Category("Modules.Comments")]
    public partial class TraktCommentsModule_Tests
    {
        private const string GET_COMMENTS_RECENT_URI = "comments/recent";

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments()
        {
            TraktClient client = TestUtility.GetMockClient(
                GET_COMMENTS_RECENT_URI,
                COMMENTS_JSON, 1, 10, 1, COMMENTS_ITEM_COUNT);

            TraktPagedResponse<ITraktUserComment> response = await client.Comments.GetRecentlyCreatedCommentsAsync();

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_With_CommentType()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}/{COMMENT_TYPE.UriName}",
                COMMENTS_JSON, 1, 10, 1, COMMENTS_ITEM_COUNT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(COMMENT_TYPE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_With_CommentType_And_ObjectType()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}/{COMMENT_TYPE.UriName}/{OBJECT_TYPE.UriName}",
                COMMENTS_JSON, 1, 10, 1, COMMENTS_ITEM_COUNT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(COMMENT_TYPE, OBJECT_TYPE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_With_CommentType_And_ObjectType_And_IncludeReplies()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}/{COMMENT_TYPE.UriName}/{OBJECT_TYPE.UriName}?include_replies=true",
                COMMENTS_JSON, 1, 10, 1, COMMENTS_ITEM_COUNT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(COMMENT_TYPE, OBJECT_TYPE, true);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_With_CommentType_And_ObjectType_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}/{COMMENT_TYPE.UriName}/{OBJECT_TYPE.UriName}?extended={EXTENDED_INFO}",
                COMMENTS_JSON, 1, 10, 1, COMMENTS_ITEM_COUNT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(COMMENT_TYPE, OBJECT_TYPE, null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_With_CommentType_And_ObjectType_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}/{COMMENT_TYPE.UriName}/{OBJECT_TYPE.UriName}?page={PAGE}",
                COMMENTS_JSON, PAGE, 10, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(COMMENT_TYPE, OBJECT_TYPE, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_With_CommentType_And_ObjectType_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}/{COMMENT_TYPE.UriName}/{OBJECT_TYPE.UriName}?limit={LIMIT}",
                COMMENTS_JSON, 1, LIMIT, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(COMMENT_TYPE, OBJECT_TYPE, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_With_CommentType_And_ObjectType_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}/{COMMENT_TYPE.UriName}/{OBJECT_TYPE.UriName}?page={PAGE}&limit={LIMIT}",
                COMMENTS_JSON, PAGE, LIMIT, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(COMMENT_TYPE, OBJECT_TYPE, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_With_CommentType_And_IncludeReplies()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}/{COMMENT_TYPE.UriName}?include_replies=true",
                COMMENTS_JSON, 1, 10, 1, COMMENTS_ITEM_COUNT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(COMMENT_TYPE, null, true);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_With_CommentType_And_IncludeReplies_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}/{COMMENT_TYPE.UriName}?include_replies=true&page={PAGE}",
                COMMENTS_JSON, PAGE, 10, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(COMMENT_TYPE, null, true, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_With_CommentType_And_IncludeReplies_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}/{COMMENT_TYPE.UriName}?include_replies=true&limit={LIMIT}",
                COMMENTS_JSON, 1, LIMIT, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(COMMENT_TYPE, null, true, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_With_CommentType_And_IncludeReplies_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}/{COMMENT_TYPE.UriName}?include_replies=true&page={PAGE}&limit={LIMIT}",
                COMMENTS_JSON, PAGE, LIMIT, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(COMMENT_TYPE, null, true, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_With_CommentType_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}/{COMMENT_TYPE.UriName}?extended={EXTENDED_INFO}",
                COMMENTS_JSON, 1, 10, 1, COMMENTS_ITEM_COUNT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(COMMENT_TYPE, null, null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_With_CommentType_And_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}/{COMMENT_TYPE.UriName}?extended={EXTENDED_INFO}&page={PAGE}",
                COMMENTS_JSON, PAGE, 10, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(COMMENT_TYPE, null, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_With_CommentType_And_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}/{COMMENT_TYPE.UriName}?extended={EXTENDED_INFO}&limit={LIMIT}",
                COMMENTS_JSON, 1, LIMIT, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(COMMENT_TYPE, null, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_With_CommentType_And_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}/{COMMENT_TYPE.UriName}?extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                COMMENTS_JSON, PAGE, LIMIT, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(COMMENT_TYPE, null, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_With_CommentType_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}/{COMMENT_TYPE.UriName}?page={PAGE}",
                COMMENTS_JSON, PAGE, 10, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(COMMENT_TYPE, null, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_With_CommentType_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}/{COMMENT_TYPE.UriName}?limit={LIMIT}",
                COMMENTS_JSON, 1, LIMIT, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(COMMENT_TYPE, null, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_With_CommentType_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}/{COMMENT_TYPE.UriName}?page={PAGE}&limit={LIMIT}",
                COMMENTS_JSON, PAGE, LIMIT, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(COMMENT_TYPE, null, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_With_ObjectType()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}/{OBJECT_TYPE.UriName}",
                COMMENTS_JSON, 1, 10, 1, COMMENTS_ITEM_COUNT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, OBJECT_TYPE);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_With_ObjectType_And_IncludeReplies()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}/{OBJECT_TYPE.UriName}?include_replies=true",
                COMMENTS_JSON, 1, 10, 1, COMMENTS_ITEM_COUNT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, OBJECT_TYPE, true);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_With_ObjectType_And_IncludeReplies_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}/{OBJECT_TYPE.UriName}?include_replies=true&page={PAGE}",
                COMMENTS_JSON, PAGE, 10, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, OBJECT_TYPE, true, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_With_ObjectType_And_IncludeReplies_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}/{OBJECT_TYPE.UriName}?include_replies=true&limit={LIMIT}",
                COMMENTS_JSON, 1, LIMIT, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, OBJECT_TYPE, true, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_With_ObjectType_And_IncludeReplies_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}/{OBJECT_TYPE.UriName}?include_replies=true&page={PAGE}&limit={LIMIT}",
                COMMENTS_JSON, PAGE, LIMIT, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, OBJECT_TYPE, true, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_With_ObjectType_And_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}/{OBJECT_TYPE.UriName}?extended={EXTENDED_INFO}",
                COMMENTS_JSON, 1, 10, 1, COMMENTS_ITEM_COUNT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, OBJECT_TYPE, null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_With_ObjectType_And_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}/{OBJECT_TYPE.UriName}?extended={EXTENDED_INFO}&page={PAGE}",
                COMMENTS_JSON, PAGE, 10, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, OBJECT_TYPE, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_With_ObjectType_And_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}/{OBJECT_TYPE.UriName}?extended={EXTENDED_INFO}&limit={LIMIT}",
                COMMENTS_JSON, 1, LIMIT, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, OBJECT_TYPE, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_With_ObjectType_And_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}/{OBJECT_TYPE.UriName}?extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                COMMENTS_JSON, PAGE, LIMIT, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, OBJECT_TYPE, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_With_ObjectType_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}/{OBJECT_TYPE.UriName}?page={PAGE}",
                COMMENTS_JSON, PAGE, 10, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, OBJECT_TYPE, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_With_ObjectType_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}/{OBJECT_TYPE.UriName}?limit={LIMIT}",
                COMMENTS_JSON, 1, LIMIT, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, OBJECT_TYPE, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_With_ObjectType_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}/{OBJECT_TYPE.UriName}?page={PAGE}&limit={LIMIT}",
                COMMENTS_JSON, PAGE, LIMIT, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, OBJECT_TYPE, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_With_IncludeReplies()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}?include_replies=true",
                COMMENTS_JSON, 1, 10, 1, COMMENTS_ITEM_COUNT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, null, true);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_With_IncludeReplies_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}?include_replies=true&page={PAGE}",
                COMMENTS_JSON, PAGE, 10, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, null, true, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_With_IncludeReplies_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}?include_replies=true&limit={LIMIT}",
                COMMENTS_JSON, 1, LIMIT, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, null, true, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_With_IncludeReplies_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}?include_replies=true&page={PAGE}&limit={LIMIT}",
                COMMENTS_JSON, PAGE, LIMIT, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, null, true, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_With_ExtendedInfo()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}?extended={EXTENDED_INFO}",
                COMMENTS_JSON, 1, 10, 1, COMMENTS_ITEM_COUNT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, null, null, EXTENDED_INFO);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_With_ExtendedInfo_And_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}?extended={EXTENDED_INFO}&page={PAGE}",
                COMMENTS_JSON, PAGE, 10, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, null, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_With_ExtendedInfo_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}?extended={EXTENDED_INFO}&limit={LIMIT}",
                COMMENTS_JSON, 1, LIMIT, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, null, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_With_ExtendedInfo_And_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}?extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                COMMENTS_JSON, PAGE, LIMIT, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, null, null, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_With_Page()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}?page={PAGE}",
                COMMENTS_JSON, PAGE, 10, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, null, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(10u);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_With_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}?limit={LIMIT}",
                COMMENTS_JSON, 1, LIMIT, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(null, LIMIT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, null, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(1u);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_With_Page_And_Limit()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}?page={PAGE}&limit={LIMIT}",
                COMMENTS_JSON, PAGE, LIMIT, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(null, null, null, null, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public async Task Test_TraktCommentsModule_GetRecentlyCreatedComments_Complete()
        {
            TraktClient client = TestUtility.GetMockClient(
                $"{GET_COMMENTS_RECENT_URI}/{COMMENT_TYPE.UriName}/{OBJECT_TYPE.UriName}" +
                $"?include_replies=true&extended={EXTENDED_INFO}&page={PAGE}&limit={LIMIT}",
                COMMENTS_JSON, PAGE, LIMIT, 1, COMMENTS_ITEM_COUNT);

            var pagedParameters = new TraktPagedParameters(PAGE, LIMIT);

            TraktPagedResponse<ITraktUserComment> response =
                await client.Comments.GetRecentlyCreatedCommentsAsync(COMMENT_TYPE, OBJECT_TYPE,
                                                    true, EXTENDED_INFO, pagedParameters);

            response.Should().NotBeNull();
            response.IsSuccess.Should().BeTrue();
            response.HasValue.Should().BeTrue();
            response.Value.Should().NotBeNull().And.HaveCount(COMMENTS_ITEM_COUNT);
            response.ItemCount.Should().HaveValue().And.Be(COMMENTS_ITEM_COUNT);
            response.Limit.Should().Be(LIMIT);
            response.Page.Should().Be(PAGE);
            response.PageCount.Should().HaveValue().And.Be(1);
        }

        [Fact]
        public void Test_TraktCommentsModule_GetRecentlyCreatedComments_Throws_NotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENTS_RECENT_URI, HttpStatusCode.NotFound);
            Func<Task<TraktPagedResponse<ITraktUserComment>>> act = () => client.Comments.GetRecentlyCreatedCommentsAsync();
            act.Should().Throw<TraktNotFoundException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetRecentlyCreatedComments_Throws_AuthorizationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENTS_RECENT_URI, HttpStatusCode.Unauthorized);
            Func<Task<TraktPagedResponse<ITraktUserComment>>> act = () => client.Comments.GetRecentlyCreatedCommentsAsync();
            act.Should().Throw<TraktAuthorizationException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetRecentlyCreatedComments_Throws_BadRequestException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENTS_RECENT_URI, HttpStatusCode.BadRequest);
            Func<Task<TraktPagedResponse<ITraktUserComment>>> act = () => client.Comments.GetRecentlyCreatedCommentsAsync();
            act.Should().Throw<TraktBadRequestException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetRecentlyCreatedComments_Throws_ForbiddenException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENTS_RECENT_URI, HttpStatusCode.Forbidden);
            Func<Task<TraktPagedResponse<ITraktUserComment>>> act = () => client.Comments.GetRecentlyCreatedCommentsAsync();
            act.Should().Throw<TraktForbiddenException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetRecentlyCreatedComments_Throws_MethodNotFoundException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENTS_RECENT_URI, HttpStatusCode.MethodNotAllowed);
            Func<Task<TraktPagedResponse<ITraktUserComment>>> act = () => client.Comments.GetRecentlyCreatedCommentsAsync();
            act.Should().Throw<TraktMethodNotFoundException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetRecentlyCreatedComments_Throws_ConflictException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENTS_RECENT_URI, HttpStatusCode.Conflict);
            Func<Task<TraktPagedResponse<ITraktUserComment>>> act = () => client.Comments.GetRecentlyCreatedCommentsAsync();
            act.Should().Throw<TraktConflictException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetRecentlyCreatedComments_Throws_ServerException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENTS_RECENT_URI, HttpStatusCode.InternalServerError);
            Func<Task<TraktPagedResponse<ITraktUserComment>>> act = () => client.Comments.GetRecentlyCreatedCommentsAsync();
            act.Should().Throw<TraktServerException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetRecentlyCreatedComments_Throws_BadGatewayException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENTS_RECENT_URI, HttpStatusCode.BadGateway);
            Func<Task<TraktPagedResponse<ITraktUserComment>>> act = () => client.Comments.GetRecentlyCreatedCommentsAsync();
            act.Should().Throw<TraktBadGatewayException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetRecentlyCreatedComments_Throws_PreconditionFailedException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENTS_RECENT_URI, (HttpStatusCode)412);
            Func<Task<TraktPagedResponse<ITraktUserComment>>> act = () => client.Comments.GetRecentlyCreatedCommentsAsync();
            act.Should().Throw<TraktPreconditionFailedException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetRecentlyCreatedComments_Throws_ValidationException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENTS_RECENT_URI, (HttpStatusCode)422);
            Func<Task<TraktPagedResponse<ITraktUserComment>>> act = () => client.Comments.GetRecentlyCreatedCommentsAsync();
            act.Should().Throw<TraktValidationException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetRecentlyCreatedComments_Throws_RateLimitException()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENTS_RECENT_URI, (HttpStatusCode)429);
            Func<Task<TraktPagedResponse<ITraktUserComment>>> act = () => client.Comments.GetRecentlyCreatedCommentsAsync();
            act.Should().Throw<TraktRateLimitException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetRecentlyCreatedComments_Throws_ServerUnavailableException_503()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENTS_RECENT_URI, (HttpStatusCode)503);
            Func<Task<TraktPagedResponse<ITraktUserComment>>> act = () => client.Comments.GetRecentlyCreatedCommentsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetRecentlyCreatedComments_Throws_ServerUnavailableException_504()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENTS_RECENT_URI, (HttpStatusCode)504);
            Func<Task<TraktPagedResponse<ITraktUserComment>>> act = () => client.Comments.GetRecentlyCreatedCommentsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetRecentlyCreatedComments_Throws_ServerUnavailableException_520()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENTS_RECENT_URI, (HttpStatusCode)520);
            Func<Task<TraktPagedResponse<ITraktUserComment>>> act = () => client.Comments.GetRecentlyCreatedCommentsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetRecentlyCreatedComments_Throws_ServerUnavailableException_521()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENTS_RECENT_URI, (HttpStatusCode)521);
            Func<Task<TraktPagedResponse<ITraktUserComment>>> act = () => client.Comments.GetRecentlyCreatedCommentsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }

        [Fact]
        public void Test_TraktCommentsModule_GetRecentlyCreatedComments_Throws_ServerUnavailableException_522()
        {
            TraktClient client = TestUtility.GetMockClient(GET_COMMENTS_RECENT_URI, (HttpStatusCode)522);
            Func<Task<TraktPagedResponse<ITraktUserComment>>> act = () => client.Comments.GetRecentlyCreatedCommentsAsync();
            act.Should().Throw<TraktServerUnavailableException>();
        }
    }
}
