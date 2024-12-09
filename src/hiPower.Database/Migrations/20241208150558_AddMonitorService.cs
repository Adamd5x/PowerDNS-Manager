using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace hiPower.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddMonitorService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_Server");

            migrationBuilder.DropTable(
                name: "T_ServerLocation");

            migrationBuilder.CreateTable(
                name: "T_MonitorService",
                columns: table => new
                {
                    ServiceId = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    MonitorState = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_MonitorService", x => x.ServiceId);
                });

            migrationBuilder.CreateTable(
                name: "T_ServiceLocation",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Address = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    City = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    Region = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    PostalCode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Country = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ServiceLocation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_StatisticsVariable",
                columns: table => new
                {
                    Variable = table.Column<string>(type: "character varying(35)", maxLength: 35, nullable: false),
                    Description = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_StatisticsVariable", x => x.Variable);
                });

            migrationBuilder.CreateTable(
                name: "T_ServiceDetails",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LocalId = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Proto = table.Column<string>(type: "character varying(10)", maxLength: 10, precision: 0, scale: 5, nullable: false),
                    HostAddress = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Port = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Version = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    ApiKey = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Auth = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    OS = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    Configuration = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    LocationId = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    MonitorId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ServiceDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_ServiceDetails_T_ServiceLocation_LocationId",
                        column: x => x.LocationId,
                        principalTable: "T_ServiceLocation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "T_MonitorVariables",
                columns: table => new
                {
                    ServiceId = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    Variable = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_MonitorVariables", x => x.ServiceId);
                    table.ForeignKey(
                        name: "FK_T_MonitorVariables_T_ServiceDetails_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "T_ServiceDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "T_ServiceLocation",
                columns: new[] { "Id", "Address", "City", "Country", "Description", "Name", "PostalCode", "Region" },
                values: new object[] { "7EB5999F-AEF5-11EF-9FD9-47F022E22A50", "", "", "Default", "Initial location", "Default", "", "" });

            migrationBuilder.InsertData(
                table: "T_StatisticsVariable",
                columns: new[] { "Variable", "Description" },
                values: new object[,]
                {
                    { "backend-queries", "Number of queries sent to the backend(s)" },
                    { "corrupt-packets", "Number of corrupt packets received" },
                    { "cpu-iowait", "Time spent waiting for I/O to complete by the whole system, in units of USER_HZ" },
                    { "cpu-steal", "Stolen time, which is the time spent by the whole system in other operating systems when running in a virtualized environment, in units of USER_HZ" },
                    { "deferred-cache-inserts", "Amount of cache inserts that were deferred because of maintenance" },
                    { "deferred-cache-lookup", "Amount of cache lookups that were deferred because of maintenance" },
                    { "deferred-packetcache-inserts", "Amount of packet cache inserts that were deferred because of maintenance" },
                    { "deferred-packetcache-lookup", "Amount of packet cache lookups that were deferred because of maintenance" },
                    { "dnsupdate-answers", "DNS update packets successfully answered." },
                    { "dnsupdate-changes", "DNS update changes to records in total." },
                    { "dnsupdate-queries", "DNS update packets received." },
                    { "dnsupdate-refused", "DNS update packets that are refused." },
                    { "fd-usage", "Number of open filedescriptors" },
                    { "incoming-notifications", "NOTIFY packets received." },
                    { "key-cache-size", "Number of entries in the key cache" },
                    { "latency", "Average number of microseconds needed to answer a question" },
                    { "meta-cache-size", "Number of entries in the metadata cache" },
                    { "noerror-packets", "Number of times a NOERROR packet was sent out" },
                    { "nxdomain-packets", "Number of times an NXDOMAIN packet was sent out" },
                    { "open-tcp-connections", "Number of currently open TCP connections" },
                    { "overload-drops", "Queries dropped because backends overloaded" },
                    { "packetcache-hit", "Number of hits on the packet cache" },
                    { "packetcache-miss", "Number of misses on the packet cache" },
                    { "packetcache-size", "Number of entries in the packet cache" },
                    { "qsize-q", "Number of questions waiting for database attention" },
                    { "query-cache-hit", "Number of hits on the query cache" },
                    { "query-cache-miss", "Number of misses on the query cache" },
                    { "query-cache-size", "Number of entries in the query cache" },
                    { "rd-queries", "Number of recursion desired questions" },
                    { "real-memory-usage", "Actual unique use of memory in bytes (approx)" },
                    { "recursing-answers", "Number of recursive answers sent out" },
                    { "recursing-questions", "Number of questions sent to recursor" },
                    { "recursion-unanswered", "Number of packets unanswered by configured recursor" },
                    { "ring-logmessages-capacity", "Maximum number of entries in the logmessages ring" },
                    { "ring-logmessages-size", "Number of entries in the logmessages ring" },
                    { "ring-noerror-queries-capacity", "Maximum number of entries in the noerror-queries ring" },
                    { "ring-noerror-queries-size", "Number of entries in the noerror-queries ring" },
                    { "ring-nxdomain-queries-capacity", "Maximum number of entries in the nxdomain-queries ring" },
                    { "ring-nxdomain-queries-size", "Number of entries in the nxdomain-queries ring" },
                    { "ring-queries-capacity", "Maximum number of entries in the queries ring" },
                    { "ring-queries-size", "Number of entries in the queries ring" },
                    { "ring-remotes-capacity", "Maximum number of entries in the remotes ring" },
                    { "ring-remotes-corrupt-capacity", "Maximum number of entries in the remotes-corrupt ring" },
                    { "ring-remotes-corrupt-size", "Number of entries in the remotes-corrupt ring" },
                    { "ring-remotes-size", "Number of entries in the remotes ring" },
                    { "ring-remotes-unauth-capacity", "Maximum number of entries in the remotes-unauth ring" },
                    { "ring-remotes-unauth-size", "Number of entries in the remotes-unauth ring" },
                    { "ring-servfail-queries-capacity", "Maximum number of entries in the servfail-queries ring" },
                    { "ring-servfail-queries-size", "Number of entries in the servfail-queries ring" },
                    { "ring-unauth-queries-capacity", "Maximum number of entries in the unauth-queries ring" },
                    { "ring-unauth-queries-size", "Number of entries in the unauth-queries ring" },
                    { "security-status", "Security status based on regular polling" },
                    { "servfail-packets", "Number of times a server-failed packet was sent out" },
                    { "signature-cache-size", "Number of entries in the signature cache" },
                    { "signatures", "Number of DNSSEC signatures made" },
                    { "sys-msec", "Number of msec spent in system time" },
                    { "tcp-answers", "Number of answers sent out over TCP" },
                    { "tcp-answers-bytes", "Total size of answers sent out over TCP" },
                    { "tcp-queries", "Number of TCP queries received" },
                    { "tcp4-answers", "Number of IPv4 answers sent out over TCP" },
                    { "tcp4-answers-bytes", "Total size of answers sent out over TCPv4" },
                    { "tcp4-queries", "Number of IPv4 TCP queries received" },
                    { "tcp6-answers", "Number of IPv6 answers sent out over TCP" },
                    { "tcp6-answers-bytes", "Total size of answers sent out over TCPv6" },
                    { "tcp6-queries", "Number of IPv6 TCP queries received" },
                    { "timedout-packets", "Number of packets which weren't answered within timeout set" },
                    { "udp-answers", "Number of answers sent out over UDP" },
                    { "udp-answers-bytes", "Total size of answers sent out over UDP" },
                    { "udp-do-queries", "Number of UDP queries received with DO bit" },
                    { "udp-in-errors", "UDP 'in' errors" },
                    { "udp-noport-errors", "UDP 'noport' errors" },
                    { "udp-queries", "Number of UDP queries received" },
                    { "udp-recvbuf-errors", "UDP 'recvbuf' errors" },
                    { "udp-sndbuf-errors", "UDP 'sndbuf' errors" },
                    { "udp4-answers", "Number of IPv4 answers sent out over UDP" },
                    { "udp4-answers-bytes", "Total size of answers sent out over UDPv4" },
                    { "udp4-queries", "Number of IPv4 UDP queries received" },
                    { "udp6-answers", "Number of IPv6 answers sent out over UDP" },
                    { "udp6-answers-bytes", "Total size of answers sent out over UDPv6" },
                    { "udp6-queries", "Number of IPv6 UDP queries received" },
                    { "unauth-packets", "Number of times a zone we are not auth for was queried" },
                    { "uptime", "Uptime of process in seconds" },
                    { "user-msec", "Number of msec spent in user time" },
                    { "xfr-queue", "Size of the queue of zones to be XFRd" },
                    { "zone-cache-hit", "Number of zone cache hits" },
                    { "zone-cache-miss", "Number of zone cache misses" },
                    { "zone-cache-size", "Number of entries in the zone cache" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_MonitorService_ServiceId_MonitorState",
                table: "T_MonitorService",
                columns: new[] { "ServiceId", "MonitorState" });

            migrationBuilder.CreateIndex(
                name: "IX_T_ServiceDetails_LocationId",
                table: "T_ServiceDetails",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_T_ServiceLocation_Name",
                table: "T_ServiceLocation",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_MonitorService");

            migrationBuilder.DropTable(
                name: "T_MonitorVariables");

            migrationBuilder.DropTable(
                name: "T_StatisticsVariable");

            migrationBuilder.DropTable(
                name: "T_ServiceDetails");

            migrationBuilder.DropTable(
                name: "T_ServiceLocation");

            migrationBuilder.CreateTable(
                name: "T_ServerLocation",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    Address = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    City = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    Country = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Region = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ServerLocation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_Server",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    LocationId = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    ApiKey = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Auth = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Configuration = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    HostAddress = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    LocalId = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    OS = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    Port = table.Column<string>(type: "text", nullable: true),
                    Proto = table.Column<string>(type: "character varying(10)", maxLength: 10, precision: 0, scale: 5, nullable: false),
                    Retries = table.Column<int>(type: "integer", precision: 0, scale: 2, nullable: false),
                    State = table.Column<int>(type: "integer", precision: 0, scale: 3, nullable: false),
                    Timeout = table.Column<int>(type: "integer", precision: 0, scale: 5, nullable: false),
                    Version = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Server", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_Server_T_ServerLocation_LocationId",
                        column: x => x.LocationId,
                        principalTable: "T_ServerLocation",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "T_ServerLocation",
                columns: new[] { "Id", "Address", "City", "Country", "Description", "Name", "PostalCode", "Region" },
                values: new object[] { "7EB5999F-AEF5-11EF-9FD9-47F022E22A50", "", "", "Default", "Initial location", "Default", "", "" });

            migrationBuilder.CreateIndex(
                name: "IX_T_Server_LocationId",
                table: "T_Server",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_T_ServerLocation_Name",
                table: "T_ServerLocation",
                column: "Name");
        }
    }
}
