using hiPower.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hiPower.Database.Configuration;

internal class StatisticsVariableEntityConfiguration : IEntityTypeConfiguration<StatisticsVariable>
{
    public void Configure (EntityTypeBuilder<StatisticsVariable> builder)
    {
        builder.ToTable ($"{Prefix.Table}{nameof (StatisticsVariable)}");

        builder.HasKey (k => k.Variable);

        builder.Property (p => p.Variable)
               .HasMaxLength (35)
               .IsRequired ();

        builder.Property (p => p.Description)
               .HasMaxLength(200);

        builder.HasData (Variables);
    }

    internal static StatisticsVariable [] Variables => [
new () {Variable = "backend-queries", Description = "Number of queries sent to the backend(s)"},
new () {Variable = "corrupt-packets", Description = "Number of corrupt packets received"},
new () {Variable = "deferred-cache-inserts", Description = "Amount of cache inserts that were deferred because of maintenance" },
new () {Variable = "deferred-cache-lookup", Description = "Amount of cache lookups that were deferred because of maintenance" },
new () {Variable = "deferred-packetcache-inserts", Description = "Amount of packet cache inserts that were deferred because of maintenance" },
new () {Variable = "deferred-packetcache-lookup", Description = "Amount of packet cache lookups that were deferred because of maintenance" },
new () {Variable = "dnsupdate-answers", Description = "DNS update packets successfully answered."},
new () {Variable = "dnsupdate-changes", Description = "DNS update changes to records in total."},
new () {Variable = "dnsupdate-queries", Description = "DNS update packets received."},
new () {Variable = "dnsupdate-refused", Description = "DNS update packets that are refused."},
new () {Variable = "incoming-notifications", Description = "NOTIFY packets received."},
new () {Variable = "noerror-packets", Description = "Number of times a NOERROR packet was sent out" },
new () {Variable = "nxdomain-packets", Description = "Number of times an NXDOMAIN packet was sent out" },
new () {Variable = "overload-drops", Description = "Queries dropped because backends overloaded" },
new () {Variable = "packetcache-hit", Description = "Number of hits on the packet cache" },
new () {Variable = "packetcache-miss", Description = "Number of misses on the packet cache" },
new () {Variable = "packetcache-size", Description = "Number of entries in the packet cache" },
new () {Variable = "query-cache-hit", Description = "Number of hits on the query cache" },
new () {Variable = "query-cache-miss", Description = "Number of misses on the query cache" },
new () {Variable = "query-cache-size", Description = "Number of entries in the query cache" },
new () {Variable = "rd-queries", Description = "Number of recursion desired questions" },
new () {Variable = "recursing-answers", Description = "Number of recursive answers sent out" },
new () {Variable = "recursing-questions", Description = "Number of questions sent to recursor" },
new () {Variable = "recursion-unanswered", Description = "Number of packets unanswered by configured recursor" },
new () {Variable = "security-status", Description = "Security status based on regular polling" },
new () {Variable = "servfail-packets", Description = "Number of times a server-failed packet was sent out" },
new () {Variable = "signatures", Description = "Number of DNSSEC signatures made" },
new () {Variable = "tcp-answers", Description = "Number of answers sent out over TCP" },
new () {Variable = "tcp-answers-bytes", Description = "Total size of answers sent out over TCP" },
new () {Variable = "tcp-queries", Description = "Number of TCP queries received" },
new () {Variable = "tcp4-answers", Description = "Number of IPv4 answers sent out over TCP" },
new () {Variable = "tcp4-answers-bytes", Description = "Total size of answers sent out over TCPv4" },
new () {Variable = "tcp4-queries", Description = "Number of IPv4 TCP queries received" },
new () {Variable = "tcp6-answers", Description = "Number of IPv6 answers sent out over TCP" },
new () {Variable = "tcp6-answers-bytes", Description = "Total size of answers sent out over TCPv6" },
new () {Variable = "tcp6-queries", Description = "Number of IPv6 TCP queries received" },
new () {Variable = "timedout-packets", Description = "Number of packets which weren't answered within timeout set" },
new () {Variable = "udp-answers", Description = "Number of answers sent out over UDP" },
new () {Variable = "udp-answers-bytes", Description = "Total size of answers sent out over UDP" },
new () {Variable = "udp-do-queries", Description = "Number of UDP queries received with DO bit" },
new () {Variable = "udp-queries", Description = "Number of UDP queries received" },
new () {Variable = "udp4-answers", Description = "Number of IPv4 answers sent out over UDP" },
new () {Variable = "udp4-answers-bytes", Description = "Total size of answers sent out over UDPv4" },
new () {Variable = "udp4-queries", Description = "Number of IPv4 UDP queries received" },
new () {Variable = "udp6-answers", Description = "Number of IPv6 answers sent out over UDP" },
new () {Variable = "udp6-answers-bytes", Description = "Total size of answers sent out over UDPv6" },
new () {Variable = "udp6-queries", Description = "Number of IPv6 UDP queries received" },
new () {Variable = "unauth-packets", Description = "Number of times a zone we are not auth for was queried" },
new () {Variable = "zone-cache-hit", Description = "Number of zone cache hits" },
new () {Variable = "zone-cache-miss", Description = "Number of zone cache misses" },
new () {Variable = "zone-cache-size", Description = "Number of entries in the zone cache" },
new () {Variable = "cpu-iowait", Description = "Time spent waiting for I/O to complete by the whole system, in units of USER_HZ" },
new () {Variable = "cpu-steal", Description = "Stolen time, which is the time spent by the whole system in other operating systems when running in a virtualized environment, in units of USER_HZ" },
new () {Variable = "fd-usage", Description = "Number of open filedescriptors" },
new () {Variable = "key-cache-size", Description = "Number of entries in the key cache" },
new () {Variable = "latency", Description = "Average number of microseconds needed to answer a question" },
new () {Variable = "meta-cache-size", Description = "Number of entries in the metadata cache" },
new () {Variable = "open-tcp-connections", Description = "Number of currently open TCP connections" },
new () {Variable = "qsize-q", Description = "Number of questions waiting for database attention" },
new () {Variable = "real-memory-usage", Description = "Actual unique use of memory in bytes (approx)" },
new () {Variable = "ring-logmessages-capacity", Description = "Maximum number of entries in the logmessages ring" },
new () {Variable = "ring-logmessages-size", Description = "Number of entries in the logmessages ring" },
new () {Variable = "ring-noerror-queries-capacity", Description = "Maximum number of entries in the noerror-queries ring" },
new () {Variable = "ring-noerror-queries-size", Description = "Number of entries in the noerror-queries ring" },
new () {Variable = "ring-nxdomain-queries-capacity", Description = "Maximum number of entries in the nxdomain-queries ring" },
new () {Variable = "ring-nxdomain-queries-size", Description = "Number of entries in the nxdomain-queries ring" },
new () {Variable = "ring-queries-capacity", Description = "Maximum number of entries in the queries ring" },
new () {Variable = "ring-queries-size", Description = "Number of entries in the queries ring" },
new () {Variable = "ring-remotes-capacity", Description = "Maximum number of entries in the remotes ring" },
new () {Variable = "ring-remotes-corrupt-capacity", Description = "Maximum number of entries in the remotes-corrupt ring" },
new () {Variable = "ring-remotes-corrupt-size", Description = "Number of entries in the remotes-corrupt ring" },
new () {Variable = "ring-remotes-size", Description = "Number of entries in the remotes ring" },
new () {Variable = "ring-remotes-unauth-capacity", Description = "Maximum number of entries in the remotes-unauth ring" },
new () {Variable = "ring-remotes-unauth-size", Description = "Number of entries in the remotes-unauth ring" },
new () {Variable = "ring-servfail-queries-capacity", Description = "Maximum number of entries in the servfail-queries ring" },
new () {Variable = "ring-servfail-queries-size", Description = "Number of entries in the servfail-queries ring" },
new () {Variable = "ring-unauth-queries-capacity", Description = "Maximum number of entries in the unauth-queries ring" },
new () {Variable = "ring-unauth-queries-size", Description = "Number of entries in the unauth-queries ring" },
new () {Variable = "signature-cache-size", Description = "Number of entries in the signature cache" },
new () {Variable = "sys-msec", Description = "Number of msec spent in system time" },
new () {Variable = "udp-in-errors", Description = "UDP 'in' errors" },
new () {Variable = "udp-noport-errors", Description = "UDP 'noport' errors" },
new () {Variable = "udp-recvbuf-errors", Description = "UDP 'recvbuf' errors" },
new () {Variable = "udp-sndbuf-errors", Description = "UDP 'sndbuf' errors" },
new () {Variable = "uptime", Description = "Uptime of process in seconds" },
new () {Variable = "user-msec", Description = "Number of msec spent in user time" },
new () {Variable = "xfr-queue", Description = "Size of the queue of zones to be XFRd" }
        ];
}
