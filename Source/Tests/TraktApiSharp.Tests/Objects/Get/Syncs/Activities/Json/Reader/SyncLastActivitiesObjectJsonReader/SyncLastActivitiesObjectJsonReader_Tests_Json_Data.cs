﻿namespace TraktApiSharp.Tests.Objects.Get.Syncs.Activities.Json.Reader
{
    public partial class SyncLastActivitiesObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""all"": ""2014-11-20T07:01:32.378Z"",
                ""movies"": {
                  ""watched_at"": ""2014-11-19T21:42:41.823Z"",
                  ""collected_at"": ""2014-11-20T06:51:30.243Z"",
                  ""rated_at"": ""2014-11-19T18:32:29.459Z"",
                  ""watchlisted_at"": ""2014-11-19T21:42:41.844Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.250Z"",
                  ""paused_at"": ""2014-11-20T06:51:30.250Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""episodes"": {
                  ""watched_at"": ""2014-11-20T06:51:30.305Z"",
                  ""collected_at"": ""2014-11-19T22:02:41.308Z"",
                  ""rated_at"": ""2014-11-20T06:51:30.310Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.321Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                  ""paused_at"": ""2014-11-20T06:51:30.250Z""
                },
                ""shows"": {
                  ""rated_at"": ""2014-11-19T19:50:58.557Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.262Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.281Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2014-11-19T19:54:24.537Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.297Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.301Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2014-11-20T03:38:09.122Z""
                },
                ""lists"": {
                  ""liked_at"": ""2014-11-20T00:36:48.506Z"",
                  ""updated_at"": ""2014-11-20T06:52:18.837Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.250Z""
                }
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""movies"": {
                  ""watched_at"": ""2014-11-19T21:42:41.823Z"",
                  ""collected_at"": ""2014-11-20T06:51:30.243Z"",
                  ""rated_at"": ""2014-11-19T18:32:29.459Z"",
                  ""watchlisted_at"": ""2014-11-19T21:42:41.844Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.250Z"",
                  ""paused_at"": ""2014-11-20T06:51:30.250Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""episodes"": {
                  ""watched_at"": ""2014-11-20T06:51:30.305Z"",
                  ""collected_at"": ""2014-11-19T22:02:41.308Z"",
                  ""rated_at"": ""2014-11-20T06:51:30.310Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.321Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                  ""paused_at"": ""2014-11-20T06:51:30.250Z""
                },
                ""shows"": {
                  ""rated_at"": ""2014-11-19T19:50:58.557Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.262Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.281Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2014-11-19T19:54:24.537Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.297Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.301Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2014-11-20T03:38:09.122Z""
                },
                ""lists"": {
                  ""liked_at"": ""2014-11-20T00:36:48.506Z"",
                  ""updated_at"": ""2014-11-20T06:52:18.837Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.250Z""
                }
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""all"": ""2014-11-20T07:01:32.378Z"",
                ""episodes"": {
                  ""watched_at"": ""2014-11-20T06:51:30.305Z"",
                  ""collected_at"": ""2014-11-19T22:02:41.308Z"",
                  ""rated_at"": ""2014-11-20T06:51:30.310Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.321Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                  ""paused_at"": ""2014-11-20T06:51:30.250Z""
                },
                ""shows"": {
                  ""rated_at"": ""2014-11-19T19:50:58.557Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.262Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.281Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2014-11-19T19:54:24.537Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.297Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.301Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2014-11-20T03:38:09.122Z""
                },
                ""lists"": {
                  ""liked_at"": ""2014-11-20T00:36:48.506Z"",
                  ""updated_at"": ""2014-11-20T06:52:18.837Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.250Z""
                }
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""all"": ""2014-11-20T07:01:32.378Z"",
                ""movies"": {
                  ""watched_at"": ""2014-11-19T21:42:41.823Z"",
                  ""collected_at"": ""2014-11-20T06:51:30.243Z"",
                  ""rated_at"": ""2014-11-19T18:32:29.459Z"",
                  ""watchlisted_at"": ""2014-11-19T21:42:41.844Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.250Z"",
                  ""paused_at"": ""2014-11-20T06:51:30.250Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""shows"": {
                  ""rated_at"": ""2014-11-19T19:50:58.557Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.262Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.281Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2014-11-19T19:54:24.537Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.297Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.301Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2014-11-20T03:38:09.122Z""
                },
                ""lists"": {
                  ""liked_at"": ""2014-11-20T00:36:48.506Z"",
                  ""updated_at"": ""2014-11-20T06:52:18.837Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.250Z""
                }
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""all"": ""2014-11-20T07:01:32.378Z"",
                ""movies"": {
                  ""watched_at"": ""2014-11-19T21:42:41.823Z"",
                  ""collected_at"": ""2014-11-20T06:51:30.243Z"",
                  ""rated_at"": ""2014-11-19T18:32:29.459Z"",
                  ""watchlisted_at"": ""2014-11-19T21:42:41.844Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.250Z"",
                  ""paused_at"": ""2014-11-20T06:51:30.250Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""episodes"": {
                  ""watched_at"": ""2014-11-20T06:51:30.305Z"",
                  ""collected_at"": ""2014-11-19T22:02:41.308Z"",
                  ""rated_at"": ""2014-11-20T06:51:30.310Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.321Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                  ""paused_at"": ""2014-11-20T06:51:30.250Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2014-11-19T19:54:24.537Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.297Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.301Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2014-11-20T03:38:09.122Z""
                },
                ""lists"": {
                  ""liked_at"": ""2014-11-20T00:36:48.506Z"",
                  ""updated_at"": ""2014-11-20T06:52:18.837Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.250Z""
                }
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""all"": ""2014-11-20T07:01:32.378Z"",
                ""movies"": {
                  ""watched_at"": ""2014-11-19T21:42:41.823Z"",
                  ""collected_at"": ""2014-11-20T06:51:30.243Z"",
                  ""rated_at"": ""2014-11-19T18:32:29.459Z"",
                  ""watchlisted_at"": ""2014-11-19T21:42:41.844Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.250Z"",
                  ""paused_at"": ""2014-11-20T06:51:30.250Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""episodes"": {
                  ""watched_at"": ""2014-11-20T06:51:30.305Z"",
                  ""collected_at"": ""2014-11-19T22:02:41.308Z"",
                  ""rated_at"": ""2014-11-20T06:51:30.310Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.321Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                  ""paused_at"": ""2014-11-20T06:51:30.250Z""
                },
                ""shows"": {
                  ""rated_at"": ""2014-11-19T19:50:58.557Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.262Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.281Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2014-11-20T03:38:09.122Z""
                },
                ""lists"": {
                  ""liked_at"": ""2014-11-20T00:36:48.506Z"",
                  ""updated_at"": ""2014-11-20T06:52:18.837Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.250Z""
                }
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""all"": ""2014-11-20T07:01:32.378Z"",
                ""movies"": {
                  ""watched_at"": ""2014-11-19T21:42:41.823Z"",
                  ""collected_at"": ""2014-11-20T06:51:30.243Z"",
                  ""rated_at"": ""2014-11-19T18:32:29.459Z"",
                  ""watchlisted_at"": ""2014-11-19T21:42:41.844Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.250Z"",
                  ""paused_at"": ""2014-11-20T06:51:30.250Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""episodes"": {
                  ""watched_at"": ""2014-11-20T06:51:30.305Z"",
                  ""collected_at"": ""2014-11-19T22:02:41.308Z"",
                  ""rated_at"": ""2014-11-20T06:51:30.310Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.321Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                  ""paused_at"": ""2014-11-20T06:51:30.250Z""
                },
                ""shows"": {
                  ""rated_at"": ""2014-11-19T19:50:58.557Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.262Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.281Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2014-11-19T19:54:24.537Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.297Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.301Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""lists"": {
                  ""liked_at"": ""2014-11-20T00:36:48.506Z"",
                  ""updated_at"": ""2014-11-20T06:52:18.837Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.250Z""
                }
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""all"": ""2014-11-20T07:01:32.378Z"",
                ""movies"": {
                  ""watched_at"": ""2014-11-19T21:42:41.823Z"",
                  ""collected_at"": ""2014-11-20T06:51:30.243Z"",
                  ""rated_at"": ""2014-11-19T18:32:29.459Z"",
                  ""watchlisted_at"": ""2014-11-19T21:42:41.844Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.250Z"",
                  ""paused_at"": ""2014-11-20T06:51:30.250Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""episodes"": {
                  ""watched_at"": ""2014-11-20T06:51:30.305Z"",
                  ""collected_at"": ""2014-11-19T22:02:41.308Z"",
                  ""rated_at"": ""2014-11-20T06:51:30.310Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.321Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                  ""paused_at"": ""2014-11-20T06:51:30.250Z""
                },
                ""shows"": {
                  ""rated_at"": ""2014-11-19T19:50:58.557Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.262Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.281Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2014-11-19T19:54:24.537Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.297Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.301Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2014-11-20T03:38:09.122Z""
                }
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""all"": ""2014-11-20T07:01:32.378Z""
              }";

        private const string JSON_INCOMPLETE_9 =
            @"{
                ""movies"": {
                  ""watched_at"": ""2014-11-19T21:42:41.823Z"",
                  ""collected_at"": ""2014-11-20T06:51:30.243Z"",
                  ""rated_at"": ""2014-11-19T18:32:29.459Z"",
                  ""watchlisted_at"": ""2014-11-19T21:42:41.844Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.250Z"",
                  ""paused_at"": ""2014-11-20T06:51:30.250Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                }
              }";

        private const string JSON_INCOMPLETE_10 =
            @"{
                ""episodes"": {
                  ""watched_at"": ""2014-11-20T06:51:30.305Z"",
                  ""collected_at"": ""2014-11-19T22:02:41.308Z"",
                  ""rated_at"": ""2014-11-20T06:51:30.310Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.321Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                  ""paused_at"": ""2014-11-20T06:51:30.250Z""
                }
              }";

        private const string JSON_INCOMPLETE_11 =
            @"{
                ""shows"": {
                  ""rated_at"": ""2014-11-19T19:50:58.557Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.262Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.281Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                }
              }";

        private const string JSON_INCOMPLETE_12 =
            @"{
                ""seasons"": {
                  ""rated_at"": ""2014-11-19T19:54:24.537Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.297Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.301Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                }
              }";

        private const string JSON_INCOMPLETE_13 =
            @"{
                ""comments"": {
                  ""liked_at"": ""2014-11-20T03:38:09.122Z""
                }
              }";

        private const string JSON_INCOMPLETE_14 =
            @"{
                ""lists"": {
                  ""liked_at"": ""2014-11-20T00:36:48.506Z"",
                  ""updated_at"": ""2014-11-20T06:52:18.837Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.250Z""
                }
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""a"": ""2014-11-20T07:01:32.378Z"",
                ""movies"": {
                  ""watched_at"": ""2014-11-19T21:42:41.823Z"",
                  ""collected_at"": ""2014-11-20T06:51:30.243Z"",
                  ""rated_at"": ""2014-11-19T18:32:29.459Z"",
                  ""watchlisted_at"": ""2014-11-19T21:42:41.844Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.250Z"",
                  ""paused_at"": ""2014-11-20T06:51:30.250Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""episodes"": {
                  ""watched_at"": ""2014-11-20T06:51:30.305Z"",
                  ""collected_at"": ""2014-11-19T22:02:41.308Z"",
                  ""rated_at"": ""2014-11-20T06:51:30.310Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.321Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                  ""paused_at"": ""2014-11-20T06:51:30.250Z""
                },
                ""shows"": {
                  ""rated_at"": ""2014-11-19T19:50:58.557Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.262Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.281Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2014-11-19T19:54:24.537Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.297Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.301Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2014-11-20T03:38:09.122Z""
                },
                ""lists"": {
                  ""liked_at"": ""2014-11-20T00:36:48.506Z"",
                  ""updated_at"": ""2014-11-20T06:52:18.837Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.250Z""
                }
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""all"": ""2014-11-20T07:01:32.378Z"",
                ""mov"": {
                  ""watched_at"": ""2014-11-19T21:42:41.823Z"",
                  ""collected_at"": ""2014-11-20T06:51:30.243Z"",
                  ""rated_at"": ""2014-11-19T18:32:29.459Z"",
                  ""watchlisted_at"": ""2014-11-19T21:42:41.844Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.250Z"",
                  ""paused_at"": ""2014-11-20T06:51:30.250Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""episodes"": {
                  ""watched_at"": ""2014-11-20T06:51:30.305Z"",
                  ""collected_at"": ""2014-11-19T22:02:41.308Z"",
                  ""rated_at"": ""2014-11-20T06:51:30.310Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.321Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                  ""paused_at"": ""2014-11-20T06:51:30.250Z""
                },
                ""shows"": {
                  ""rated_at"": ""2014-11-19T19:50:58.557Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.262Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.281Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2014-11-19T19:54:24.537Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.297Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.301Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2014-11-20T03:38:09.122Z""
                },
                ""lists"": {
                  ""liked_at"": ""2014-11-20T00:36:48.506Z"",
                  ""updated_at"": ""2014-11-20T06:52:18.837Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.250Z""
                }
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""all"": ""2014-11-20T07:01:32.378Z"",
                ""movies"": {
                  ""watched_at"": ""2014-11-19T21:42:41.823Z"",
                  ""collected_at"": ""2014-11-20T06:51:30.243Z"",
                  ""rated_at"": ""2014-11-19T18:32:29.459Z"",
                  ""watchlisted_at"": ""2014-11-19T21:42:41.844Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.250Z"",
                  ""paused_at"": ""2014-11-20T06:51:30.250Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""eps"": {
                  ""watched_at"": ""2014-11-20T06:51:30.305Z"",
                  ""collected_at"": ""2014-11-19T22:02:41.308Z"",
                  ""rated_at"": ""2014-11-20T06:51:30.310Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.321Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                  ""paused_at"": ""2014-11-20T06:51:30.250Z""
                },
                ""shows"": {
                  ""rated_at"": ""2014-11-19T19:50:58.557Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.262Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.281Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2014-11-19T19:54:24.537Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.297Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.301Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2014-11-20T03:38:09.122Z""
                },
                ""lists"": {
                  ""liked_at"": ""2014-11-20T00:36:48.506Z"",
                  ""updated_at"": ""2014-11-20T06:52:18.837Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.250Z""
                }
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""all"": ""2014-11-20T07:01:32.378Z"",
                ""movies"": {
                  ""watched_at"": ""2014-11-19T21:42:41.823Z"",
                  ""collected_at"": ""2014-11-20T06:51:30.243Z"",
                  ""rated_at"": ""2014-11-19T18:32:29.459Z"",
                  ""watchlisted_at"": ""2014-11-19T21:42:41.844Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.250Z"",
                  ""paused_at"": ""2014-11-20T06:51:30.250Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""episodes"": {
                  ""watched_at"": ""2014-11-20T06:51:30.305Z"",
                  ""collected_at"": ""2014-11-19T22:02:41.308Z"",
                  ""rated_at"": ""2014-11-20T06:51:30.310Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.321Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                  ""paused_at"": ""2014-11-20T06:51:30.250Z""
                },
                ""sh"": {
                  ""rated_at"": ""2014-11-19T19:50:58.557Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.262Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.281Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2014-11-19T19:54:24.537Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.297Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.301Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2014-11-20T03:38:09.122Z""
                },
                ""lists"": {
                  ""liked_at"": ""2014-11-20T00:36:48.506Z"",
                  ""updated_at"": ""2014-11-20T06:52:18.837Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.250Z""
                }
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""all"": ""2014-11-20T07:01:32.378Z"",
                ""movies"": {
                  ""watched_at"": ""2014-11-19T21:42:41.823Z"",
                  ""collected_at"": ""2014-11-20T06:51:30.243Z"",
                  ""rated_at"": ""2014-11-19T18:32:29.459Z"",
                  ""watchlisted_at"": ""2014-11-19T21:42:41.844Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.250Z"",
                  ""paused_at"": ""2014-11-20T06:51:30.250Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""episodes"": {
                  ""watched_at"": ""2014-11-20T06:51:30.305Z"",
                  ""collected_at"": ""2014-11-19T22:02:41.308Z"",
                  ""rated_at"": ""2014-11-20T06:51:30.310Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.321Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                  ""paused_at"": ""2014-11-20T06:51:30.250Z""
                },
                ""shows"": {
                  ""rated_at"": ""2014-11-19T19:50:58.557Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.262Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.281Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""sea"": {
                  ""rated_at"": ""2014-11-19T19:54:24.537Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.297Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.301Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2014-11-20T03:38:09.122Z""
                },
                ""lists"": {
                  ""liked_at"": ""2014-11-20T00:36:48.506Z"",
                  ""updated_at"": ""2014-11-20T06:52:18.837Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.250Z""
                }
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
                ""all"": ""2014-11-20T07:01:32.378Z"",
                ""movies"": {
                  ""watched_at"": ""2014-11-19T21:42:41.823Z"",
                  ""collected_at"": ""2014-11-20T06:51:30.243Z"",
                  ""rated_at"": ""2014-11-19T18:32:29.459Z"",
                  ""watchlisted_at"": ""2014-11-19T21:42:41.844Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.250Z"",
                  ""paused_at"": ""2014-11-20T06:51:30.250Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""episodes"": {
                  ""watched_at"": ""2014-11-20T06:51:30.305Z"",
                  ""collected_at"": ""2014-11-19T22:02:41.308Z"",
                  ""rated_at"": ""2014-11-20T06:51:30.310Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.321Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                  ""paused_at"": ""2014-11-20T06:51:30.250Z""
                },
                ""shows"": {
                  ""rated_at"": ""2014-11-19T19:50:58.557Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.262Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.281Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2014-11-19T19:54:24.537Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.297Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.301Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""com"": {
                  ""liked_at"": ""2014-11-20T03:38:09.122Z""
                },
                ""lists"": {
                  ""liked_at"": ""2014-11-20T00:36:48.506Z"",
                  ""updated_at"": ""2014-11-20T06:52:18.837Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.250Z""
                }
              }";

        private const string JSON_NOT_VALID_7 =
            @"{
                ""all"": ""2014-11-20T07:01:32.378Z"",
                ""movies"": {
                  ""watched_at"": ""2014-11-19T21:42:41.823Z"",
                  ""collected_at"": ""2014-11-20T06:51:30.243Z"",
                  ""rated_at"": ""2014-11-19T18:32:29.459Z"",
                  ""watchlisted_at"": ""2014-11-19T21:42:41.844Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.250Z"",
                  ""paused_at"": ""2014-11-20T06:51:30.250Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""episodes"": {
                  ""watched_at"": ""2014-11-20T06:51:30.305Z"",
                  ""collected_at"": ""2014-11-19T22:02:41.308Z"",
                  ""rated_at"": ""2014-11-20T06:51:30.310Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.321Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                  ""paused_at"": ""2014-11-20T06:51:30.250Z""
                },
                ""shows"": {
                  ""rated_at"": ""2014-11-19T19:50:58.557Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.262Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.281Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""seasons"": {
                  ""rated_at"": ""2014-11-19T19:54:24.537Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.297Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.301Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""comments"": {
                  ""liked_at"": ""2014-11-20T03:38:09.122Z""
                },
                ""li"": {
                  ""liked_at"": ""2014-11-20T00:36:48.506Z"",
                  ""updated_at"": ""2014-11-20T06:52:18.837Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.250Z""
                }
              }";

        private const string JSON_NOT_VALID_8 =
            @"{
                ""a"": ""2014-11-20T07:01:32.378Z"",
                ""mov"": {
                  ""watched_at"": ""2014-11-19T21:42:41.823Z"",
                  ""collected_at"": ""2014-11-20T06:51:30.243Z"",
                  ""rated_at"": ""2014-11-19T18:32:29.459Z"",
                  ""watchlisted_at"": ""2014-11-19T21:42:41.844Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.250Z"",
                  ""paused_at"": ""2014-11-20T06:51:30.250Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""eps"": {
                  ""watched_at"": ""2014-11-20T06:51:30.305Z"",
                  ""collected_at"": ""2014-11-19T22:02:41.308Z"",
                  ""rated_at"": ""2014-11-20T06:51:30.310Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.321Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.325Z"",
                  ""paused_at"": ""2014-11-20T06:51:30.250Z""
                },
                ""sh"": {
                  ""rated_at"": ""2014-11-19T19:50:58.557Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.262Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.281Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""sea"": {
                  ""rated_at"": ""2014-11-19T19:54:24.537Z"",
                  ""watchlisted_at"": ""2014-11-20T06:51:30.297Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.301Z"",
                  ""hidden_at"": ""2016-08-20T06:51:30.000Z""
                },
                ""com"": {
                  ""liked_at"": ""2014-11-20T03:38:09.122Z""
                },
                ""li"": {
                  ""liked_at"": ""2014-11-20T00:36:48.506Z"",
                  ""updated_at"": ""2014-11-20T06:52:18.837Z"",
                  ""commented_at"": ""2014-11-20T06:51:30.250Z""
                }
              }";
    }
}
