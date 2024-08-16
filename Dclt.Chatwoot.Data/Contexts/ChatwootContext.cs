using Microsoft.EntityFrameworkCore;
using Dclt.Chatwoot.Entities;

namespace Dclt.Chatwoot.Contexts;

public partial class ChatwootContext : DbContext
{
    public ChatwootContext()
    {
    }

    public ChatwootContext(DbContextOptions<ChatwootContext> options) : base(options)
    {
    }

    public virtual DbSet<AccessToken> AccessTokens { get; set; }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AccountUser> AccountUsers { get; set; }

    public virtual DbSet<ActionMailboxInboundEmail> ActionMailboxInboundEmails { get; set; }

    public virtual DbSet<ActiveStorageAttachment> ActiveStorageAttachments { get; set; }

    public virtual DbSet<ActiveStorageBlob> ActiveStorageBlobs { get; set; }

    public virtual DbSet<ActiveStorageVariantRecord> ActiveStorageVariantRecords { get; set; }

    public virtual DbSet<AgentBot> AgentBots { get; set; }

    public virtual DbSet<AgentBotInbox> AgentBotInboxes { get; set; }

    public virtual DbSet<AppliedSla> AppliedSlas { get; set; }

    public virtual DbSet<ArInternalMetadatum> ArInternalMetadata { get; set; }

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<Attachment> Attachments { get; set; }

    public virtual DbSet<Audit> Audits { get; set; }

    public virtual DbSet<AutomationRule> AutomationRules { get; set; }

    public virtual DbSet<Campaign> Campaigns { get; set; }

    public virtual DbSet<CannedResponse> CannedResponses { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<ChannelApi> ChannelApis { get; set; }

    public virtual DbSet<ChannelEmail> ChannelEmails { get; set; }

    public virtual DbSet<ChannelFacebookPage> ChannelFacebookPages { get; set; }

    public virtual DbSet<ChannelLine> ChannelLines { get; set; }

    public virtual DbSet<ChannelSm> ChannelSms { get; set; }

    public virtual DbSet<ChannelTelegram> ChannelTelegrams { get; set; }

    public virtual DbSet<ChannelTwilioSm> ChannelTwilioSms { get; set; }

    public virtual DbSet<ChannelTwitterProfile> ChannelTwitterProfiles { get; set; }

    public virtual DbSet<ChannelWebWidget> ChannelWebWidgets { get; set; }

    public virtual DbSet<ChannelWhatsapp> ChannelWhatsapps { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<ContactInbox> ContactInboxes { get; set; }

    public virtual DbSet<Conversation> Conversations { get; set; }

    public virtual DbSet<ConversationParticipant> ConversationParticipants { get; set; }

    public virtual DbSet<CsatSurveyResponse> CsatSurveyResponses { get; set; }

    public virtual DbSet<CustomAttributeDefinition> CustomAttributeDefinitions { get; set; }

    public virtual DbSet<CustomFilter> CustomFilters { get; set; }

    public virtual DbSet<DashboardApp> DashboardApps { get; set; }

    public virtual DbSet<DataImport> DataImports { get; set; }

    public virtual DbSet<EmailTemplate> EmailTemplates { get; set; }

    public virtual DbSet<Folder> Folders { get; set; }

    public virtual DbSet<Inbox> Inboxes { get; set; }

    public virtual DbSet<InboxMember> InboxMembers { get; set; }

    public virtual DbSet<InstallationConfig> InstallationConfigs { get; set; }

    public virtual DbSet<IntegrationsHook> IntegrationsHooks { get; set; }

    public virtual DbSet<Label> Labels { get; set; }

    public virtual DbSet<Macro> Macros { get; set; }

    public virtual DbSet<Mention> Mentions { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Note> Notes { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<NotificationSetting> NotificationSettings { get; set; }

    public virtual DbSet<NotificationSubscription> NotificationSubscriptions { get; set; }

    public virtual DbSet<PlatformApp> PlatformApps { get; set; }

    public virtual DbSet<PlatformAppPermissible> PlatformAppPermissibles { get; set; }

    public virtual DbSet<Portal> Portals { get; set; }

    public virtual DbSet<PortalMember> PortalMembers { get; set; }

    public virtual DbSet<PortalsMember> PortalsMembers { get; set; }

    public virtual DbSet<RelatedCategory> RelatedCategories { get; set; }

    public virtual DbSet<ReportingEvent> ReportingEvents { get; set; }

    public virtual DbSet<SchemaMigration> SchemaMigrations { get; set; }

    public virtual DbSet<SlaEvent> SlaEvents { get; set; }

    public virtual DbSet<SlaPolicy> SlaPolicies { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<Tagging> Taggings { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<TeamMember> TeamMembers { get; set; }

    public virtual DbSet<TelegramBot> TelegramBots { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Webhook> Webhooks { get; set; }

    public virtual DbSet<WorkingHour> WorkingHours { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasPostgresExtension("pg_stat_statements")
            .HasPostgresExtension("pg_trgm")
            .HasPostgresExtension("pgcrypto");

        modelBuilder.Entity<AccessToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("access_tokens_pkey");

            entity.ToTable("access_tokens");

            entity.HasIndex(e => new { e.OwnerType, e.OwnerId }, "index_access_tokens_on_owner_type_and_owner_id");

            entity.HasIndex(e => e.Token, "index_access_tokens_on_token").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.OwnerId).HasColumnName("owner_id");
            entity.Property(e => e.OwnerType)
                .HasColumnType("character varying")
                .HasColumnName("owner_type");
            entity.Property(e => e.Token)
                .HasColumnType("character varying")
                .HasColumnName("token");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("accounts_pkey");

            entity.ToTable("accounts");

            entity.HasIndex(e => e.Status, "index_accounts_on_status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AutoResolveDuration).HasColumnName("auto_resolve_duration");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CustomAttributes)
                .HasDefaultValueSql("'{}'::jsonb")
                .HasColumnType("jsonb")
                .HasColumnName("custom_attributes");
            entity.Property(e => e.Domain)
                .HasMaxLength(100)
                .HasColumnName("domain");
            entity.Property(e => e.FeatureFlags)
                .HasDefaultValue(0L)
                .HasColumnName("feature_flags");
            entity.Property(e => e.Limits)
                .HasDefaultValueSql("'{}'::jsonb")
                .HasColumnType("jsonb")
                .HasColumnName("limits");
            entity.Property(e => e.Locale)
                .HasDefaultValue(0)
                .HasColumnName("locale");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Status)
                .HasDefaultValue(0)
                .HasColumnName("status");
            entity.Property(e => e.SupportEmail)
                .HasMaxLength(100)
                .HasColumnName("support_email");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<AccountUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("account_users_pkey");

            entity.ToTable("account_users");

            entity.HasIndex(e => e.AccountId, "index_account_users_on_account_id");

            entity.HasIndex(e => e.UserId, "index_account_users_on_user_id");

            entity.HasIndex(e => new { e.AccountId, e.UserId }, "uniq_user_id_per_account_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.ActiveAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("active_at");
            entity.Property(e => e.AutoOffline)
                .HasDefaultValue(true)
                .HasColumnName("auto_offline");
            entity.Property(e => e.Availability)
                .HasDefaultValue(0)
                .HasColumnName("availability");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.InviterId).HasColumnName("inviter_id");
            entity.Property(e => e.Role)
                .HasDefaultValue(0)
                .HasColumnName("role");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<ActionMailboxInboundEmail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("action_mailbox_inbound_emails_pkey");

            entity.ToTable("action_mailbox_inbound_emails");

            entity.HasIndex(e => new { e.MessageId, e.MessageChecksum }, "index_action_mailbox_inbound_emails_uniqueness").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.MessageChecksum)
                .HasColumnType("character varying")
                .HasColumnName("message_checksum");
            entity.Property(e => e.MessageId)
                .HasColumnType("character varying")
                .HasColumnName("message_id");
            entity.Property(e => e.Status)
                .HasDefaultValue(0)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ActiveStorageAttachment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("active_storage_attachments_pkey");

            entity.ToTable("active_storage_attachments");

            entity.HasIndex(e => e.BlobId, "index_active_storage_attachments_on_blob_id");

            entity.HasIndex(e => new { e.RecordType, e.RecordId, e.Name, e.BlobId }, "index_active_storage_attachments_uniqueness").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BlobId).HasColumnName("blob_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.RecordId).HasColumnName("record_id");
            entity.Property(e => e.RecordType)
                .HasColumnType("character varying")
                .HasColumnName("record_type");

            entity.HasOne(d => d.Blob).WithMany(p => p.ActiveStorageAttachments)
                .HasForeignKey(d => d.BlobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_rails_c3b3935057");
        });

        modelBuilder.Entity<ActiveStorageBlob>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("active_storage_blobs_pkey");

            entity.ToTable("active_storage_blobs");

            entity.HasIndex(e => e.Key, "index_active_storage_blobs_on_key").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ByteSize).HasColumnName("byte_size");
            entity.Property(e => e.Checksum)
                .HasColumnType("character varying")
                .HasColumnName("checksum");
            entity.Property(e => e.ContentType)
                .HasColumnType("character varying")
                .HasColumnName("content_type");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Filename)
                .HasColumnType("character varying")
                .HasColumnName("filename");
            entity.Property(e => e.Key)
                .HasColumnType("character varying")
                .HasColumnName("key");
            entity.Property(e => e.Metadata).HasColumnName("metadata");
            entity.Property(e => e.ServiceName)
                .HasColumnType("character varying")
                .HasColumnName("service_name");
        });

        modelBuilder.Entity<ActiveStorageVariantRecord>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("active_storage_variant_records_pkey");

            entity.ToTable("active_storage_variant_records");

            entity.HasIndex(e => new { e.BlobId, e.VariationDigest }, "index_active_storage_variant_records_uniqueness").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.BlobId).HasColumnName("blob_id");
            entity.Property(e => e.VariationDigest)
                .HasColumnType("character varying")
                .HasColumnName("variation_digest");

            entity.HasOne(d => d.Blob).WithMany(p => p.ActiveStorageVariantRecords)
                .HasForeignKey(d => d.BlobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_rails_993965df05");
        });

        modelBuilder.Entity<AgentBot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("agent_bots_pkey");

            entity.ToTable("agent_bots");

            entity.HasIndex(e => e.AccountId, "index_agent_bots_on_account_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.BotConfig)
                .HasDefaultValueSql("'{}'::jsonb")
                .HasColumnType("jsonb")
                .HasColumnName("bot_config");
            entity.Property(e => e.BotType)
                .HasDefaultValue(0)
                .HasColumnName("bot_type");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.OutgoingUrl)
                .HasColumnType("character varying")
                .HasColumnName("outgoing_url");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<AgentBotInbox>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("agent_bot_inboxes_pkey");

            entity.ToTable("agent_bot_inboxes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.AgentBotId).HasColumnName("agent_bot_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.InboxId).HasColumnName("inbox_id");
            entity.Property(e => e.Status)
                .HasDefaultValue(0)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<AppliedSla>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("applied_slas_pkey");

            entity.ToTable("applied_slas");

            entity.HasIndex(e => e.AccountId, "index_applied_slas_on_account_id");

            entity.HasIndex(e => new { e.AccountId, e.SlaPolicyId, e.ConversationId }, "index_applied_slas_on_account_sla_policy_conversation").IsUnique();

            entity.HasIndex(e => e.ConversationId, "index_applied_slas_on_conversation_id");

            entity.HasIndex(e => e.SlaPolicyId, "index_applied_slas_on_sla_policy_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.ConversationId).HasColumnName("conversation_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.SlaPolicyId).HasColumnName("sla_policy_id");
            entity.Property(e => e.SlaStatus)
                .HasDefaultValue(0)
                .HasColumnName("sla_status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ArInternalMetadatum>(entity =>
        {
            entity.HasKey(e => e.Key).HasName("ar_internal_metadata_pkey");

            entity.ToTable("ar_internal_metadata");

            entity.Property(e => e.Key)
                .HasColumnType("character varying")
                .HasColumnName("key");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.Value)
                .HasColumnType("character varying")
                .HasColumnName("value");
        });

        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("articles_pkey");

            entity.ToTable("articles");

            entity.HasIndex(e => e.AssociatedArticleId, "index_articles_on_associated_article_id");

            entity.HasIndex(e => e.AuthorId, "index_articles_on_author_id");

            entity.HasIndex(e => e.Slug, "index_articles_on_slug").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.AssociatedArticleId).HasColumnName("associated_article_id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.FolderId).HasColumnName("folder_id");
            entity.Property(e => e.Meta)
                .HasDefaultValueSql("'{}'::jsonb")
                .HasColumnType("jsonb")
                .HasColumnName("meta");
            entity.Property(e => e.PortalId).HasColumnName("portal_id");
            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.Slug)
                .HasColumnType("character varying")
                .HasColumnName("slug");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.Views).HasColumnName("views");
        });

        modelBuilder.Entity<Attachment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("attachments_pkey");

            entity.ToTable("attachments");

            entity.HasIndex(e => e.AccountId, "index_attachments_on_account_id");

            entity.HasIndex(e => e.MessageId, "index_attachments_on_message_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CoordinatesLat)
                .HasDefaultValueSql("0.0")
                .HasColumnName("coordinates_lat");
            entity.Property(e => e.CoordinatesLong)
                .HasDefaultValueSql("0.0")
                .HasColumnName("coordinates_long");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Extension)
                .HasColumnType("character varying")
                .HasColumnName("extension");
            entity.Property(e => e.ExternalUrl)
                .HasColumnType("character varying")
                .HasColumnName("external_url");
            entity.Property(e => e.FallbackTitle)
                .HasColumnType("character varying")
                .HasColumnName("fallback_title");
            entity.Property(e => e.FileType)
                .HasDefaultValue(0)
                .HasColumnName("file_type");
            entity.Property(e => e.MessageId).HasColumnName("message_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Audit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("audits_pkey");

            entity.ToTable("audits");

            entity.HasIndex(e => new { e.AssociatedType, e.AssociatedId }, "associated_index");

            entity.HasIndex(e => new { e.AuditableType, e.AuditableId, e.Version }, "auditable_index");

            entity.HasIndex(e => e.CreatedAt, "index_audits_on_created_at");

            entity.HasIndex(e => e.RequestUuid, "index_audits_on_request_uuid");

            entity.HasIndex(e => new { e.UserId, e.UserType }, "user_index");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Action)
                .HasColumnType("character varying")
                .HasColumnName("action");
            entity.Property(e => e.AssociatedId).HasColumnName("associated_id");
            entity.Property(e => e.AssociatedType)
                .HasColumnType("character varying")
                .HasColumnName("associated_type");
            entity.Property(e => e.AuditableId).HasColumnName("auditable_id");
            entity.Property(e => e.AuditableType)
                .HasColumnType("character varying")
                .HasColumnName("auditable_type");
            entity.Property(e => e.AuditedChanges)
                .HasColumnType("jsonb")
                .HasColumnName("audited_changes");
            entity.Property(e => e.Comment)
                .HasColumnType("character varying")
                .HasColumnName("comment");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.RemoteAddress)
                .HasColumnType("character varying")
                .HasColumnName("remote_address");
            entity.Property(e => e.RequestUuid)
                .HasColumnType("character varying")
                .HasColumnName("request_uuid");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.UserType)
                .HasColumnType("character varying")
                .HasColumnName("user_type");
            entity.Property(e => e.Username)
                .HasColumnType("character varying")
                .HasColumnName("username");
            entity.Property(e => e.Version)
                .HasDefaultValue(0)
                .HasColumnName("version");
        });

        modelBuilder.Entity<AutomationRule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("automation_rules_pkey");

            entity.ToTable("automation_rules");

            entity.HasIndex(e => e.AccountId, "index_automation_rules_on_account_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Actions)
                .HasDefaultValueSql("'\"{}\"'::jsonb")
                .HasColumnType("jsonb")
                .HasColumnName("actions");
            entity.Property(e => e.Active)
                .HasDefaultValue(true)
                .HasColumnName("active");
            entity.Property(e => e.Conditions)
                .HasDefaultValueSql("'\"{}\"'::jsonb")
                .HasColumnType("jsonb")
                .HasColumnName("conditions");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.EventName)
                .HasColumnType("character varying")
                .HasColumnName("event_name");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Campaign>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("campaigns_pkey");

            entity.ToTable("campaigns");

            entity.HasIndex(e => e.AccountId, "index_campaigns_on_account_id");

            entity.HasIndex(e => e.CampaignStatus, "index_campaigns_on_campaign_status");

            entity.HasIndex(e => e.CampaignType, "index_campaigns_on_campaign_type");

            entity.HasIndex(e => e.InboxId, "index_campaigns_on_inbox_id");

            entity.HasIndex(e => e.ScheduledAt, "index_campaigns_on_scheduled_at");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Audience)
                .HasDefaultValueSql("'[]'::jsonb")
                .HasColumnType("jsonb")
                .HasColumnName("audience");
            entity.Property(e => e.CampaignStatus)
                .HasDefaultValue(0)
                .HasColumnName("campaign_status");
            entity.Property(e => e.CampaignType)
                .HasDefaultValue(0)
                .HasColumnName("campaign_type");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.DisplayId).HasColumnName("display_id");
            entity.Property(e => e.Enabled)
                .HasDefaultValue(true)
                .HasColumnName("enabled");
            entity.Property(e => e.InboxId).HasColumnName("inbox_id");
            entity.Property(e => e.Message).HasColumnName("message");
            entity.Property(e => e.ScheduledAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("scheduled_at");
            entity.Property(e => e.SenderId).HasColumnName("sender_id");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");
            entity.Property(e => e.TriggerOnlyDuringBusinessHours)
                .HasDefaultValue(false)
                .HasColumnName("trigger_only_during_business_hours");
            entity.Property(e => e.TriggerRules)
                .HasDefaultValueSql("'{}'::jsonb")
                .HasColumnType("jsonb")
                .HasColumnName("trigger_rules");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<CannedResponse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("canned_responses_pkey");

            entity.ToTable("canned_responses");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.ShortCode)
                .HasColumnType("character varying")
                .HasColumnName("short_code");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categories_pkey");

            entity.ToTable("categories");

            entity.HasIndex(e => e.AssociatedCategoryId, "index_categories_on_associated_category_id");

            entity.HasIndex(e => e.Locale, "index_categories_on_locale");

            entity.HasIndex(e => new { e.Locale, e.AccountId }, "index_categories_on_locale_and_account_id");

            entity.HasIndex(e => e.ParentCategoryId, "index_categories_on_parent_category_id");

            entity.HasIndex(e => new { e.Slug, e.Locale, e.PortalId }, "index_categories_on_slug_and_locale_and_portal_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.AssociatedCategoryId).HasColumnName("associated_category_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Icon)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("icon");
            entity.Property(e => e.Locale)
                .HasDefaultValueSql("'en'::character varying")
                .HasColumnType("character varying")
                .HasColumnName("locale");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.ParentCategoryId).HasColumnName("parent_category_id");
            entity.Property(e => e.PortalId).HasColumnName("portal_id");
            entity.Property(e => e.Position).HasColumnName("position");
            entity.Property(e => e.Slug)
                .HasColumnType("character varying")
                .HasColumnName("slug");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ChannelApi>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("channel_api_pkey");

            entity.ToTable("channel_api");

            entity.HasIndex(e => e.HmacToken, "index_channel_api_on_hmac_token").IsUnique();

            entity.HasIndex(e => e.Identifier, "index_channel_api_on_identifier").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.AdditionalAttributes)
                .HasDefaultValueSql("'{}'::jsonb")
                .HasColumnType("jsonb")
                .HasColumnName("additional_attributes");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.HmacMandatory)
                .HasDefaultValue(false)
                .HasColumnName("hmac_mandatory");
            entity.Property(e => e.HmacToken)
                .HasColumnType("character varying")
                .HasColumnName("hmac_token");
            entity.Property(e => e.Identifier)
                .HasColumnType("character varying")
                .HasColumnName("identifier");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.WebhookUrl)
                .HasColumnType("character varying")
                .HasColumnName("webhook_url");
        });

        modelBuilder.Entity<ChannelEmail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("channel_email_pkey");

            entity.ToTable("channel_email");

            entity.HasIndex(e => e.Email, "index_channel_email_on_email").IsUnique();

            entity.HasIndex(e => e.ForwardToEmail, "index_channel_email_on_forward_to_email").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.ForwardToEmail)
                .HasColumnType("character varying")
                .HasColumnName("forward_to_email");
            entity.Property(e => e.ImapAddress)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("imap_address");
            entity.Property(e => e.ImapEnableSsl)
                .HasDefaultValue(true)
                .HasColumnName("imap_enable_ssl");
            entity.Property(e => e.ImapEnabled)
                .HasDefaultValue(false)
                .HasColumnName("imap_enabled");
            entity.Property(e => e.ImapLogin)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("imap_login");
            entity.Property(e => e.ImapPassword)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("imap_password");
            entity.Property(e => e.ImapPort)
                .HasDefaultValue(0)
                .HasColumnName("imap_port");
            entity.Property(e => e.Provider)
                .HasColumnType("character varying")
                .HasColumnName("provider");
            entity.Property(e => e.ProviderConfig)
                .HasDefaultValueSql("'{}'::jsonb")
                .HasColumnType("jsonb")
                .HasColumnName("provider_config");
            entity.Property(e => e.SmtpAddress)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("smtp_address");
            entity.Property(e => e.SmtpAuthentication)
                .HasDefaultValueSql("'login'::character varying")
                .HasColumnType("character varying")
                .HasColumnName("smtp_authentication");
            entity.Property(e => e.SmtpDomain)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("smtp_domain");
            entity.Property(e => e.SmtpEnableSslTls)
                .HasDefaultValue(false)
                .HasColumnName("smtp_enable_ssl_tls");
            entity.Property(e => e.SmtpEnableStarttlsAuto)
                .HasDefaultValue(true)
                .HasColumnName("smtp_enable_starttls_auto");
            entity.Property(e => e.SmtpEnabled)
                .HasDefaultValue(false)
                .HasColumnName("smtp_enabled");
            entity.Property(e => e.SmtpLogin)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("smtp_login");
            entity.Property(e => e.SmtpOpensslVerifyMode)
                .HasDefaultValueSql("'none'::character varying")
                .HasColumnType("character varying")
                .HasColumnName("smtp_openssl_verify_mode");
            entity.Property(e => e.SmtpPassword)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("smtp_password");
            entity.Property(e => e.SmtpPort)
                .HasDefaultValue(0)
                .HasColumnName("smtp_port");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ChannelFacebookPage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("channel_facebook_pages_pkey");

            entity.ToTable("channel_facebook_pages");

            entity.HasIndex(e => e.PageId, "index_channel_facebook_pages_on_page_id");

            entity.HasIndex(e => new { e.PageId, e.AccountId }, "index_channel_facebook_pages_on_page_id_and_account_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.InstagramId)
                .HasColumnType("character varying")
                .HasColumnName("instagram_id");
            entity.Property(e => e.PageAccessToken)
                .HasColumnType("character varying")
                .HasColumnName("page_access_token");
            entity.Property(e => e.PageId)
                .HasColumnType("character varying")
                .HasColumnName("page_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserAccessToken)
                .HasColumnType("character varying")
                .HasColumnName("user_access_token");
        });

        modelBuilder.Entity<ChannelLine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("channel_line_pkey");

            entity.ToTable("channel_line");

            entity.HasIndex(e => e.LineChannelId, "index_channel_line_on_line_channel_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.LineChannelId)
                .HasColumnType("character varying")
                .HasColumnName("line_channel_id");
            entity.Property(e => e.LineChannelSecret)
                .HasColumnType("character varying")
                .HasColumnName("line_channel_secret");
            entity.Property(e => e.LineChannelToken)
                .HasColumnType("character varying")
                .HasColumnName("line_channel_token");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ChannelSm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("channel_sms_pkey");

            entity.ToTable("channel_sms");

            entity.HasIndex(e => e.PhoneNumber, "index_channel_sms_on_phone_number").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.PhoneNumber)
                .HasColumnType("character varying")
                .HasColumnName("phone_number");
            entity.Property(e => e.Provider)
                .HasDefaultValueSql("'default'::character varying")
                .HasColumnType("character varying")
                .HasColumnName("provider");
            entity.Property(e => e.ProviderConfig)
                .HasDefaultValueSql("'{}'::jsonb")
                .HasColumnType("jsonb")
                .HasColumnName("provider_config");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ChannelTelegram>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("channel_telegram_pkey");

            entity.ToTable("channel_telegram");

            entity.HasIndex(e => e.BotToken, "index_channel_telegram_on_bot_token").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.BotName)
                .HasColumnType("character varying")
                .HasColumnName("bot_name");
            entity.Property(e => e.BotToken)
                .HasColumnType("character varying")
                .HasColumnName("bot_token");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ChannelTwilioSm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("channel_twilio_sms_pkey");

            entity.ToTable("channel_twilio_sms");

            entity.HasIndex(e => new { e.AccountSid, e.PhoneNumber }, "index_channel_twilio_sms_on_account_sid_and_phone_number").IsUnique();

            entity.HasIndex(e => e.MessagingServiceSid, "index_channel_twilio_sms_on_messaging_service_sid").IsUnique();

            entity.HasIndex(e => e.PhoneNumber, "index_channel_twilio_sms_on_phone_number").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.AccountSid)
                .HasColumnType("character varying")
                .HasColumnName("account_sid");
            entity.Property(e => e.ApiKeySid)
                .HasColumnType("character varying")
                .HasColumnName("api_key_sid");
            entity.Property(e => e.AuthToken)
                .HasColumnType("character varying")
                .HasColumnName("auth_token");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Medium)
                .HasDefaultValue(0)
                .HasColumnName("medium");
            entity.Property(e => e.MessagingServiceSid)
                .HasColumnType("character varying")
                .HasColumnName("messaging_service_sid");
            entity.Property(e => e.PhoneNumber)
                .HasColumnType("character varying")
                .HasColumnName("phone_number");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ChannelTwitterProfile>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("channel_twitter_profiles_pkey");

            entity.ToTable("channel_twitter_profiles");

            entity.HasIndex(e => new { e.AccountId, e.ProfileId }, "index_channel_twitter_profiles_on_account_id_and_profile_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.ProfileId)
                .HasColumnType("character varying")
                .HasColumnName("profile_id");
            entity.Property(e => e.TweetsEnabled)
                .HasDefaultValue(true)
                .HasColumnName("tweets_enabled");
            entity.Property(e => e.TwitterAccessToken)
                .HasColumnType("character varying")
                .HasColumnName("twitter_access_token");
            entity.Property(e => e.TwitterAccessTokenSecret)
                .HasColumnType("character varying")
                .HasColumnName("twitter_access_token_secret");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ChannelWebWidget>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("channel_web_widgets_pkey");

            entity.ToTable("channel_web_widgets");

            entity.HasIndex(e => e.HmacToken, "index_channel_web_widgets_on_hmac_token").IsUnique();

            entity.HasIndex(e => e.WebsiteToken, "index_channel_web_widgets_on_website_token").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.ContinuityViaEmail)
                .HasDefaultValue(true)
                .HasColumnName("continuity_via_email");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.FeatureFlags)
                .HasDefaultValue(7)
                .HasColumnName("feature_flags");
            entity.Property(e => e.HmacMandatory)
                .HasDefaultValue(false)
                .HasColumnName("hmac_mandatory");
            entity.Property(e => e.HmacToken)
                .HasColumnType("character varying")
                .HasColumnName("hmac_token");
            entity.Property(e => e.PreChatFormEnabled)
                .HasDefaultValue(false)
                .HasColumnName("pre_chat_form_enabled");
            entity.Property(e => e.PreChatFormOptions)
                .HasDefaultValueSql("'{}'::jsonb")
                .HasColumnType("jsonb")
                .HasColumnName("pre_chat_form_options");
            entity.Property(e => e.ReplyTime)
                .HasDefaultValue(0)
                .HasColumnName("reply_time");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.WebsiteToken)
                .HasColumnType("character varying")
                .HasColumnName("website_token");
            entity.Property(e => e.WebsiteUrl)
                .HasColumnType("character varying")
                .HasColumnName("website_url");
            entity.Property(e => e.WelcomeTagline)
                .HasColumnType("character varying")
                .HasColumnName("welcome_tagline");
            entity.Property(e => e.WelcomeTitle)
                .HasColumnType("character varying")
                .HasColumnName("welcome_title");
            entity.Property(e => e.WidgetColor)
                .HasDefaultValueSql("'#1f93ff'::character varying")
                .HasColumnType("character varying")
                .HasColumnName("widget_color");
        });

        modelBuilder.Entity<ChannelWhatsapp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("channel_whatsapp_pkey");

            entity.ToTable("channel_whatsapp");

            entity.HasIndex(e => e.PhoneNumber, "index_channel_whatsapp_on_phone_number").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.MessageTemplates)
                .HasDefaultValueSql("'{}'::jsonb")
                .HasColumnType("jsonb")
                .HasColumnName("message_templates");
            entity.Property(e => e.MessageTemplatesLastUpdated)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("message_templates_last_updated");
            entity.Property(e => e.PhoneNumber)
                .HasColumnType("character varying")
                .HasColumnName("phone_number");
            entity.Property(e => e.Provider)
                .HasDefaultValueSql("'default'::character varying")
                .HasColumnType("character varying")
                .HasColumnName("provider");
            entity.Property(e => e.ProviderConfig)
                .HasDefaultValueSql("'{}'::jsonb")
                .HasColumnType("jsonb")
                .HasColumnName("provider_config");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("contacts_pkey");

            entity.ToTable("contacts");

            entity.HasIndex(e => e.AccountId, "index_contacts_on_account_id");

            entity.HasIndex(e => e.Blocked, "index_contacts_on_blocked");

            entity.HasIndex(e => new { e.Name, e.Email, e.PhoneNumber, e.Identifier }, "index_contacts_on_name_email_phone_number_identifier")
                .HasMethod("gin")
                .HasOperators(new[] { "gin_trgm_ops", "gin_trgm_ops", "gin_trgm_ops", "gin_trgm_ops" });

            entity.HasIndex(e => new { e.AccountId, e.Email, e.PhoneNumber, e.Identifier }, "index_contacts_on_nonempty_fields").HasFilter("(((email)::text <> ''::text) OR ((phone_number)::text <> ''::text) OR ((identifier)::text <> ''::text))");

            entity.HasIndex(e => new { e.PhoneNumber, e.AccountId }, "index_contacts_on_phone_number_and_account_id");

            entity.HasIndex(e => e.AccountId, "index_resolved_contact_account_id").HasFilter("(((email)::text <> ''::text) OR ((phone_number)::text <> ''::text) OR ((identifier)::text <> ''::text))");

            entity.HasIndex(e => new { e.Email, e.AccountId }, "uniq_email_per_account_contact").IsUnique();

            entity.HasIndex(e => new { e.Identifier, e.AccountId }, "uniq_identifier_per_account_contact").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.AdditionalAttributes)
                .HasDefaultValueSql("'{}'::jsonb")
                .HasColumnType("jsonb")
                .HasColumnName("additional_attributes");
            entity.Property(e => e.Blocked)
                .HasDefaultValue(false)
                .HasColumnName("blocked");
            entity.Property(e => e.ContactType)
                .HasDefaultValue(0)
                .HasColumnName("contact_type");
            entity.Property(e => e.CountryCode)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("country_code");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CustomAttributes)
                .HasDefaultValueSql("'{}'::jsonb")
                .HasColumnType("jsonb")
                .HasColumnName("custom_attributes");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.Identifier)
                .HasColumnType("character varying")
                .HasColumnName("identifier");
            entity.Property(e => e.LastActivityAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_activity_at");
            entity.Property(e => e.LastName)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("last_name");
            entity.Property(e => e.Location)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("location");
            entity.Property(e => e.MiddleName)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("middle_name");
            entity.Property(e => e.Name)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.PhoneNumber)
                .HasColumnType("character varying")
                .HasColumnName("phone_number");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ContactInbox>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("contact_inboxes_pkey");

            entity.ToTable("contact_inboxes");

            entity.HasIndex(e => e.ContactId, "index_contact_inboxes_on_contact_id");

            entity.HasIndex(e => e.InboxId, "index_contact_inboxes_on_inbox_id");

            entity.HasIndex(e => new { e.InboxId, e.SourceId }, "index_contact_inboxes_on_inbox_id_and_source_id").IsUnique();

            entity.HasIndex(e => e.PubsubToken, "index_contact_inboxes_on_pubsub_token").IsUnique();

            entity.HasIndex(e => e.SourceId, "index_contact_inboxes_on_source_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ContactId).HasColumnName("contact_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.HmacVerified)
                .HasDefaultValue(false)
                .HasColumnName("hmac_verified");
            entity.Property(e => e.InboxId).HasColumnName("inbox_id");
            entity.Property(e => e.PubsubToken)
                .HasColumnType("character varying")
                .HasColumnName("pubsub_token");
            entity.Property(e => e.SourceId)
                .HasColumnType("character varying")
                .HasColumnName("source_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Conversation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("conversations_pkey");

            entity.ToTable("conversations");

            entity.HasIndex(e => new { e.AccountId, e.InboxId, e.Status, e.AssigneeId }, "conv_acid_inbid_stat_asgnid_idx");

            entity.HasIndex(e => e.AccountId, "index_conversations_on_account_id");

            entity.HasIndex(e => new { e.AccountId, e.DisplayId }, "index_conversations_on_account_id_and_display_id").IsUnique();

            entity.HasIndex(e => new { e.AssigneeId, e.AccountId }, "index_conversations_on_assignee_id_and_account_id");

            entity.HasIndex(e => e.CampaignId, "index_conversations_on_campaign_id");

            entity.HasIndex(e => e.ContactId, "index_conversations_on_contact_id");

            entity.HasIndex(e => e.ContactInboxId, "index_conversations_on_contact_inbox_id");

            entity.HasIndex(e => e.FirstReplyCreatedAt, "index_conversations_on_first_reply_created_at");

            entity.HasIndex(e => new { e.AccountId, e.Id }, "index_conversations_on_id_and_account_id");

            entity.HasIndex(e => e.InboxId, "index_conversations_on_inbox_id");

            entity.HasIndex(e => e.LastActivityAt, "index_conversations_on_last_activity_at");

            entity.HasIndex(e => e.Priority, "index_conversations_on_priority");

            entity.HasIndex(e => new { e.Status, e.AccountId }, "index_conversations_on_status_and_account_id");

            entity.HasIndex(e => new { e.Status, e.Priority }, "index_conversations_on_status_and_priority");

            entity.HasIndex(e => e.TeamId, "index_conversations_on_team_id");

            entity.HasIndex(e => e.Uuid, "index_conversations_on_uuid").IsUnique();

            entity.HasIndex(e => e.WaitingSince, "index_conversations_on_waiting_since");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.AdditionalAttributes)
                .HasDefaultValueSql("'{}'::jsonb")
                .HasColumnType("jsonb")
                .HasColumnName("additional_attributes");
            entity.Property(e => e.AgentLastSeenAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("agent_last_seen_at");
            entity.Property(e => e.AssigneeId).HasColumnName("assignee_id");
            entity.Property(e => e.AssigneeLastSeenAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("assignee_last_seen_at");
            entity.Property(e => e.CachedLabelList).HasColumnName("cached_label_list");
            entity.Property(e => e.CampaignId).HasColumnName("campaign_id");
            entity.Property(e => e.ContactId).HasColumnName("contact_id");
            entity.Property(e => e.ContactInboxId).HasColumnName("contact_inbox_id");
            entity.Property(e => e.ContactLastSeenAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("contact_last_seen_at");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CustomAttributes)
                .HasDefaultValueSql("'{}'::jsonb")
                .HasColumnType("jsonb")
                .HasColumnName("custom_attributes");
            entity.Property(e => e.DisplayId).HasColumnName("display_id");
            entity.Property(e => e.FirstReplyCreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("first_reply_created_at");
            entity.Property(e => e.Identifier)
                .HasColumnType("character varying")
                .HasColumnName("identifier");
            entity.Property(e => e.InboxId).HasColumnName("inbox_id");
            entity.Property(e => e.LastActivityAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_activity_at");
            entity.Property(e => e.Priority).HasColumnName("priority");
            entity.Property(e => e.SlaPolicyId).HasColumnName("sla_policy_id");
            entity.Property(e => e.SnoozedUntil)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("snoozed_until");
            entity.Property(e => e.Status)
                .HasDefaultValue(0)
                .HasColumnName("status");
            entity.Property(e => e.TeamId).HasColumnName("team_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.Uuid)
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnName("uuid");
            entity.Property(e => e.WaitingSince)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("waiting_since");
        });

        modelBuilder.Entity<ConversationParticipant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("conversation_participants_pkey");

            entity.ToTable("conversation_participants");

            entity.HasIndex(e => e.AccountId, "index_conversation_participants_on_account_id");

            entity.HasIndex(e => e.ConversationId, "index_conversation_participants_on_conversation_id");

            entity.HasIndex(e => e.UserId, "index_conversation_participants_on_user_id");

            entity.HasIndex(e => new { e.UserId, e.ConversationId }, "index_conversation_participants_on_user_id_and_conversation_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.ConversationId).HasColumnName("conversation_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<CsatSurveyResponse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("csat_survey_responses_pkey");

            entity.ToTable("csat_survey_responses");

            entity.HasIndex(e => e.AccountId, "index_csat_survey_responses_on_account_id");

            entity.HasIndex(e => e.AssignedAgentId, "index_csat_survey_responses_on_assigned_agent_id");

            entity.HasIndex(e => e.ContactId, "index_csat_survey_responses_on_contact_id");

            entity.HasIndex(e => e.ConversationId, "index_csat_survey_responses_on_conversation_id");

            entity.HasIndex(e => e.MessageId, "index_csat_survey_responses_on_message_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.AssignedAgentId).HasColumnName("assigned_agent_id");
            entity.Property(e => e.ContactId).HasColumnName("contact_id");
            entity.Property(e => e.ConversationId).HasColumnName("conversation_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.FeedbackMessage).HasColumnName("feedback_message");
            entity.Property(e => e.MessageId).HasColumnName("message_id");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<CustomAttributeDefinition>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("custom_attribute_definitions_pkey");

            entity.ToTable("custom_attribute_definitions");

            entity.HasIndex(e => new { e.AttributeKey, e.AttributeModel, e.AccountId }, "attribute_key_model_index").IsUnique();

            entity.HasIndex(e => e.AccountId, "index_custom_attribute_definitions_on_account_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.AttributeDescription).HasColumnName("attribute_description");
            entity.Property(e => e.AttributeDisplayName)
                .HasColumnType("character varying")
                .HasColumnName("attribute_display_name");
            entity.Property(e => e.AttributeDisplayType)
                .HasDefaultValue(0)
                .HasColumnName("attribute_display_type");
            entity.Property(e => e.AttributeKey)
                .HasColumnType("character varying")
                .HasColumnName("attribute_key");
            entity.Property(e => e.AttributeModel)
                .HasDefaultValue(0)
                .HasColumnName("attribute_model");
            entity.Property(e => e.AttributeValues)
                .HasDefaultValueSql("'[]'::jsonb")
                .HasColumnType("jsonb")
                .HasColumnName("attribute_values");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DefaultValue).HasColumnName("default_value");
            entity.Property(e => e.RegexCue)
                .HasColumnType("character varying")
                .HasColumnName("regex_cue");
            entity.Property(e => e.RegexPattern)
                .HasColumnType("character varying")
                .HasColumnName("regex_pattern");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<CustomFilter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("custom_filters_pkey");

            entity.ToTable("custom_filters");

            entity.HasIndex(e => e.AccountId, "index_custom_filters_on_account_id");

            entity.HasIndex(e => e.UserId, "index_custom_filters_on_user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.FilterType)
                .HasDefaultValue(0)
                .HasColumnName("filter_type");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Query)
                .HasDefaultValueSql("'\"{}\"'::jsonb")
                .HasColumnType("jsonb")
                .HasColumnName("query");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<DashboardApp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dashboard_apps_pkey");

            entity.ToTable("dashboard_apps");

            entity.HasIndex(e => e.AccountId, "index_dashboard_apps_on_account_id");

            entity.HasIndex(e => e.UserId, "index_dashboard_apps_on_user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Content)
                .HasDefaultValueSql("'[]'::jsonb")
                .HasColumnType("jsonb")
                .HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<DataImport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("data_imports_pkey");

            entity.ToTable("data_imports");

            entity.HasIndex(e => e.AccountId, "index_data_imports_on_account_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DataType)
                .HasColumnType("character varying")
                .HasColumnName("data_type");
            entity.Property(e => e.ProcessedRecords).HasColumnName("processed_records");
            entity.Property(e => e.ProcessingErrors).HasColumnName("processing_errors");
            entity.Property(e => e.Status)
                .HasDefaultValue(0)
                .HasColumnName("status");
            entity.Property(e => e.TotalRecords).HasColumnName("total_records");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<EmailTemplate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("email_templates_pkey");

            entity.ToTable("email_templates");

            entity.HasIndex(e => new { e.Name, e.AccountId }, "index_email_templates_on_name_and_account_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Body).HasColumnName("body");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Locale)
                .HasDefaultValue(0)
                .HasColumnName("locale");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.TemplateType)
                .HasDefaultValue(1)
                .HasColumnName("template_type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Folder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("folders_pkey");

            entity.ToTable("folders");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Inbox>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("inboxes_pkey");

            entity.ToTable("inboxes");

            entity.HasIndex(e => e.AccountId, "index_inboxes_on_account_id");

            entity.HasIndex(e => new { e.ChannelId, e.ChannelType }, "index_inboxes_on_channel_id_and_channel_type");

            entity.HasIndex(e => e.PortalId, "index_inboxes_on_portal_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.AllowMessagesAfterResolved)
                .HasDefaultValue(true)
                .HasColumnName("allow_messages_after_resolved");
            entity.Property(e => e.AutoAssignmentConfig)
                .HasDefaultValueSql("'{}'::jsonb")
                .HasColumnType("jsonb")
                .HasColumnName("auto_assignment_config");
            entity.Property(e => e.BusinessName)
                .HasColumnType("character varying")
                .HasColumnName("business_name");
            entity.Property(e => e.ChannelId).HasColumnName("channel_id");
            entity.Property(e => e.ChannelType)
                .HasColumnType("character varying")
                .HasColumnName("channel_type");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CsatSurveyEnabled)
                .HasDefaultValue(false)
                .HasColumnName("csat_survey_enabled");
            entity.Property(e => e.EmailAddress)
                .HasColumnType("character varying")
                .HasColumnName("email_address");
            entity.Property(e => e.EnableAutoAssignment)
                .HasDefaultValue(true)
                .HasColumnName("enable_auto_assignment");
            entity.Property(e => e.EnableEmailCollect)
                .HasDefaultValue(true)
                .HasColumnName("enable_email_collect");
            entity.Property(e => e.GreetingEnabled)
                .HasDefaultValue(false)
                .HasColumnName("greeting_enabled");
            entity.Property(e => e.GreetingMessage)
                .HasColumnType("character varying")
                .HasColumnName("greeting_message");
            entity.Property(e => e.LockToSingleConversation)
                .HasDefaultValue(false)
                .HasColumnName("lock_to_single_conversation");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.OutOfOfficeMessage)
                .HasColumnType("character varying")
                .HasColumnName("out_of_office_message");
            entity.Property(e => e.PortalId).HasColumnName("portal_id");
            entity.Property(e => e.SenderNameType)
                .HasDefaultValue(0)
                .HasColumnName("sender_name_type");
            entity.Property(e => e.Timezone)
                .HasDefaultValueSql("'UTC'::character varying")
                .HasColumnType("character varying")
                .HasColumnName("timezone");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.WorkingHoursEnabled)
                .HasDefaultValue(false)
                .HasColumnName("working_hours_enabled");

            entity.HasOne(d => d.Portal).WithMany(p => p.Inboxes)
                .HasForeignKey(d => d.PortalId)
                .HasConstraintName("fk_rails_a1f654bf2d");
        });

        modelBuilder.Entity<InboxMember>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("inbox_members_pkey");

            entity.ToTable("inbox_members");

            entity.HasIndex(e => e.InboxId, "index_inbox_members_on_inbox_id");

            entity.HasIndex(e => new { e.InboxId, e.UserId }, "index_inbox_members_on_inbox_id_and_user_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.InboxId).HasColumnName("inbox_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<InstallationConfig>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("installation_configs_pkey");

            entity.ToTable("installation_configs");

            entity.HasIndex(e => e.Name, "index_installation_configs_on_name").IsUnique();

            entity.HasIndex(e => new { e.Name, e.CreatedAt }, "index_installation_configs_on_name_and_created_at").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Locked)
                .HasDefaultValue(true)
                .HasColumnName("locked");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.SerializedValue)
                .HasDefaultValueSql("'{}'::jsonb")
                .HasColumnType("jsonb")
                .HasColumnName("serialized_value");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<IntegrationsHook>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("integrations_hooks_pkey");

            entity.ToTable("integrations_hooks");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccessToken)
                .HasColumnType("character varying")
                .HasColumnName("access_token");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.AppId)
                .HasColumnType("character varying")
                .HasColumnName("app_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.HookType)
                .HasDefaultValue(0)
                .HasColumnName("hook_type");
            entity.Property(e => e.InboxId).HasColumnName("inbox_id");
            entity.Property(e => e.ReferenceId)
                .HasColumnType("character varying")
                .HasColumnName("reference_id");
            entity.Property(e => e.Settings)
                .HasDefaultValueSql("'{}'::jsonb")
                .HasColumnType("jsonb")
                .HasColumnName("settings");
            entity.Property(e => e.Status)
                .HasDefaultValue(1)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Label>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("labels_pkey");

            entity.ToTable("labels");

            entity.HasIndex(e => e.AccountId, "index_labels_on_account_id");

            entity.HasIndex(e => new { e.Title, e.AccountId }, "index_labels_on_title_and_account_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Color)
                .HasDefaultValueSql("'#1f93ff'::character varying")
                .HasColumnType("character varying")
                .HasColumnName("color");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.ShowOnSidebar).HasColumnName("show_on_sidebar");
            entity.Property(e => e.Title)
                .HasColumnType("character varying")
                .HasColumnName("title");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Macro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("macros_pkey");

            entity.ToTable("macros");

            entity.HasIndex(e => e.AccountId, "index_macros_on_account_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Actions)
                .HasDefaultValueSql("'{}'::jsonb")
                .HasColumnType("jsonb")
                .HasColumnName("actions");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedById).HasColumnName("created_by_id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedById).HasColumnName("updated_by_id");
            entity.Property(e => e.Visibility)
                .HasDefaultValue(0)
                .HasColumnName("visibility");
        });

        modelBuilder.Entity<Mention>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("mentions_pkey");

            entity.ToTable("mentions");

            entity.HasIndex(e => e.AccountId, "index_mentions_on_account_id");

            entity.HasIndex(e => e.ConversationId, "index_mentions_on_conversation_id");

            entity.HasIndex(e => e.UserId, "index_mentions_on_user_id");

            entity.HasIndex(e => new { e.UserId, e.ConversationId }, "index_mentions_on_user_id_and_conversation_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.ConversationId).HasColumnName("conversation_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.MentionedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("mentioned_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("messages_pkey");

            entity.ToTable("messages");

            entity.HasIndex(e => e.AccountId, "index_messages_on_account_id");

            entity.HasIndex(e => new { e.AccountId, e.InboxId }, "index_messages_on_account_id_and_inbox_id");

            entity.HasIndex(e => e.Content, "index_messages_on_content")
                .HasMethod("gin")
                .HasOperators(new[] { "gin_trgm_ops" });

            entity.HasIndex(e => new { e.ConversationId, e.AccountId, e.MessageType, e.CreatedAt }, "index_messages_on_conversation_account_type_created");

            entity.HasIndex(e => e.ConversationId, "index_messages_on_conversation_id");

            entity.HasIndex(e => e.CreatedAt, "index_messages_on_created_at");

            entity.HasIndex(e => e.InboxId, "index_messages_on_inbox_id");

            entity.HasIndex(e => new { e.SenderType, e.SenderId }, "index_messages_on_sender_type_and_sender_id");

            entity.HasIndex(e => e.SourceId, "index_messages_on_source_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.AdditionalAttributes)
                .HasDefaultValueSql("'{}'::jsonb")
                .HasColumnType("jsonb")
                .HasColumnName("additional_attributes");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.ContentAttributes)
                .HasDefaultValueSql("'{}'::json")
                .HasColumnType("json")
                .HasColumnName("content_attributes");
            entity.Property(e => e.ContentType)
                .HasDefaultValue(0)
                .HasColumnName("content_type");
            entity.Property(e => e.ConversationId).HasColumnName("conversation_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.ExternalSourceIds)
                .HasDefaultValueSql("'{}'::jsonb")
                .HasColumnType("jsonb")
                .HasColumnName("external_source_ids");
            entity.Property(e => e.InboxId).HasColumnName("inbox_id");
            entity.Property(e => e.MessageType).HasColumnName("message_type");
            entity.Property(e => e.Private)
                .HasDefaultValue(false)
                .HasColumnName("private");
            entity.Property(e => e.ProcessedMessageContent).HasColumnName("processed_message_content");
            entity.Property(e => e.SenderId).HasColumnName("sender_id");
            entity.Property(e => e.SenderType)
                .HasColumnType("character varying")
                .HasColumnName("sender_type");
            entity.Property(e => e.Sentiment)
                .HasDefaultValueSql("'{}'::jsonb")
                .HasColumnType("jsonb")
                .HasColumnName("sentiment");
            entity.Property(e => e.SourceId)
                .HasColumnType("character varying")
                .HasColumnName("source_id");
            entity.Property(e => e.Status)
                .HasDefaultValue(0)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Note>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("notes_pkey");

            entity.ToTable("notes");

            entity.HasIndex(e => e.AccountId, "index_notes_on_account_id");

            entity.HasIndex(e => e.ContactId, "index_notes_on_contact_id");

            entity.HasIndex(e => e.UserId, "index_notes_on_user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.ContactId).HasColumnName("contact_id");
            entity.Property(e => e.Content).HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("notifications_pkey");

            entity.ToTable("notifications");

            entity.HasIndex(e => e.AccountId, "index_notifications_on_account_id");

            entity.HasIndex(e => e.LastActivityAt, "index_notifications_on_last_activity_at");

            entity.HasIndex(e => e.UserId, "index_notifications_on_user_id");

            entity.HasIndex(e => new { e.PrimaryActorType, e.PrimaryActorId }, "uniq_primary_actor_per_account_notifications");

            entity.HasIndex(e => new { e.SecondaryActorType, e.SecondaryActorId }, "uniq_secondary_actor_per_account_notifications");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.LastActivityAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("last_activity_at");
            entity.Property(e => e.Meta)
                .HasDefaultValueSql("'{}'::jsonb")
                .HasColumnType("jsonb")
                .HasColumnName("meta");
            entity.Property(e => e.NotificationType).HasColumnName("notification_type");
            entity.Property(e => e.PrimaryActorId).HasColumnName("primary_actor_id");
            entity.Property(e => e.PrimaryActorType)
                .HasColumnType("character varying")
                .HasColumnName("primary_actor_type");
            entity.Property(e => e.ReadAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("read_at");
            entity.Property(e => e.SecondaryActorId).HasColumnName("secondary_actor_id");
            entity.Property(e => e.SecondaryActorType)
                .HasColumnType("character varying")
                .HasColumnName("secondary_actor_type");
            entity.Property(e => e.SnoozedUntil)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("snoozed_until");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<NotificationSetting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("notification_settings_pkey");

            entity.ToTable("notification_settings");

            entity.HasIndex(e => new { e.AccountId, e.UserId }, "by_account_user").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.EmailFlags)
                .HasDefaultValue(0)
                .HasColumnName("email_flags");
            entity.Property(e => e.PushFlags)
                .HasDefaultValue(0)
                .HasColumnName("push_flags");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<NotificationSubscription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("notification_subscriptions_pkey");

            entity.ToTable("notification_subscriptions");

            entity.HasIndex(e => e.Identifier, "index_notification_subscriptions_on_identifier").IsUnique();

            entity.HasIndex(e => e.UserId, "index_notification_subscriptions_on_user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Identifier).HasColumnName("identifier");
            entity.Property(e => e.SubscriptionAttributes)
                .HasDefaultValueSql("'{}'::jsonb")
                .HasColumnType("jsonb")
                .HasColumnName("subscription_attributes");
            entity.Property(e => e.SubscriptionType).HasColumnName("subscription_type");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<PlatformApp>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("platform_apps_pkey");

            entity.ToTable("platform_apps");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<PlatformAppPermissible>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("platform_app_permissibles_pkey");

            entity.ToTable("platform_app_permissibles");

            entity.HasIndex(e => new { e.PermissibleType, e.PermissibleId }, "index_platform_app_permissibles_on_permissibles");

            entity.HasIndex(e => e.PlatformAppId, "index_platform_app_permissibles_on_platform_app_id");

            entity.HasIndex(e => new { e.PlatformAppId, e.PermissibleId, e.PermissibleType }, "unique_permissibles_index").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.PermissibleId).HasColumnName("permissible_id");
            entity.Property(e => e.PermissibleType)
                .HasColumnType("character varying")
                .HasColumnName("permissible_type");
            entity.Property(e => e.PlatformAppId).HasColumnName("platform_app_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Portal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("portals_pkey");

            entity.ToTable("portals");

            entity.HasIndex(e => e.ChannelWebWidgetId, "index_portals_on_channel_web_widget_id");

            entity.HasIndex(e => e.CustomDomain, "index_portals_on_custom_domain").IsUnique();

            entity.HasIndex(e => e.Slug, "index_portals_on_slug").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Archived)
                .HasDefaultValue(false)
                .HasColumnName("archived");
            entity.Property(e => e.ChannelWebWidgetId).HasColumnName("channel_web_widget_id");
            entity.Property(e => e.Color)
                .HasColumnType("character varying")
                .HasColumnName("color");
            entity.Property(e => e.Config)
                .HasDefaultValueSql("'{\"allowed_locales\": [\"en\"]}'::jsonb")
                .HasColumnType("jsonb")
                .HasColumnName("config");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CustomDomain)
                .HasColumnType("character varying")
                .HasColumnName("custom_domain");
            entity.Property(e => e.HeaderText).HasColumnName("header_text");
            entity.Property(e => e.HomepageLink)
                .HasColumnType("character varying")
                .HasColumnName("homepage_link");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.PageTitle)
                .HasColumnType("character varying")
                .HasColumnName("page_title");
            entity.Property(e => e.Slug)
                .HasColumnType("character varying")
                .HasColumnName("slug");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<PortalMember>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("portal_members_pkey");

            entity.ToTable("portal_members");

            entity.HasIndex(e => new { e.PortalId, e.UserId }, "index_portal_members_on_portal_id_and_user_id").IsUnique();

            entity.HasIndex(e => new { e.UserId, e.PortalId }, "index_portal_members_on_user_id_and_portal_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.PortalId).HasColumnName("portal_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<PortalsMember>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("portals_members");

            entity.HasIndex(e => e.PortalId, "index_portals_members_on_portal_id");

            entity.HasIndex(e => new { e.PortalId, e.UserId }, "index_portals_members_on_portal_id_and_user_id").IsUnique();

            entity.HasIndex(e => e.UserId, "index_portals_members_on_user_id");

            entity.Property(e => e.PortalId).HasColumnName("portal_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<RelatedCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("related_categories_pkey");

            entity.ToTable("related_categories");

            entity.HasIndex(e => new { e.CategoryId, e.RelatedCategoryId }, "index_related_categories_on_category_id_and_related_category_id").IsUnique();

            entity.HasIndex(e => new { e.RelatedCategoryId, e.CategoryId }, "index_related_categories_on_related_category_id_and_category_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CategoryId).HasColumnName("category_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.RelatedCategoryId).HasColumnName("related_category_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<ReportingEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("reporting_events_pkey");

            entity.ToTable("reporting_events");

            entity.HasIndex(e => e.AccountId, "index_reporting_events_on_account_id");

            entity.HasIndex(e => e.ConversationId, "index_reporting_events_on_conversation_id");

            entity.HasIndex(e => e.CreatedAt, "index_reporting_events_on_created_at");

            entity.HasIndex(e => e.InboxId, "index_reporting_events_on_inbox_id");

            entity.HasIndex(e => e.Name, "index_reporting_events_on_name");

            entity.HasIndex(e => e.UserId, "index_reporting_events_on_user_id");

            entity.HasIndex(e => new { e.AccountId, e.Name, e.CreatedAt }, "reporting_events__account_id__name__created_at");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.ConversationId).HasColumnName("conversation_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.EventEndTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("event_end_time");
            entity.Property(e => e.EventStartTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("event_start_time");
            entity.Property(e => e.InboxId).HasColumnName("inbox_id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Value).HasColumnName("value");
            entity.Property(e => e.ValueInBusinessHours).HasColumnName("value_in_business_hours");
        });

        modelBuilder.Entity<SchemaMigration>(entity =>
        {
            entity.HasKey(e => e.Version).HasName("schema_migrations_pkey");

            entity.ToTable("schema_migrations");

            entity.Property(e => e.Version)
                .HasColumnType("character varying")
                .HasColumnName("version");
        });

        modelBuilder.Entity<SlaEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sla_events_pkey");

            entity.ToTable("sla_events");

            entity.HasIndex(e => e.AccountId, "index_sla_events_on_account_id");

            entity.HasIndex(e => e.AppliedSlaId, "index_sla_events_on_applied_sla_id");

            entity.HasIndex(e => e.ConversationId, "index_sla_events_on_conversation_id");

            entity.HasIndex(e => e.InboxId, "index_sla_events_on_inbox_id");

            entity.HasIndex(e => e.SlaPolicyId, "index_sla_events_on_sla_policy_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.AppliedSlaId).HasColumnName("applied_sla_id");
            entity.Property(e => e.ConversationId).HasColumnName("conversation_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.EventType).HasColumnName("event_type");
            entity.Property(e => e.InboxId).HasColumnName("inbox_id");
            entity.Property(e => e.Meta)
                .HasDefaultValueSql("'{}'::jsonb")
                .HasColumnType("jsonb")
                .HasColumnName("meta");
            entity.Property(e => e.SlaPolicyId).HasColumnName("sla_policy_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<SlaPolicy>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sla_policies_pkey");

            entity.ToTable("sla_policies");

            entity.HasIndex(e => e.AccountId, "index_sla_policies_on_account_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Description)
                .HasColumnType("character varying")
                .HasColumnName("description");
            entity.Property(e => e.FirstResponseTimeThreshold).HasColumnName("first_response_time_threshold");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.NextResponseTimeThreshold).HasColumnName("next_response_time_threshold");
            entity.Property(e => e.OnlyDuringBusinessHours)
                .HasDefaultValue(false)
                .HasColumnName("only_during_business_hours");
            entity.Property(e => e.ResolutionTimeThreshold).HasColumnName("resolution_time_threshold");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("tags_pkey");

            entity.ToTable("tags");

            entity.HasIndex(e => e.Name, "index_tags_on_name").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.TaggingsCount)
                .HasDefaultValue(0)
                .HasColumnName("taggings_count");
        });

        modelBuilder.Entity<Tagging>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("taggings_pkey");

            entity.ToTable("taggings");

            entity.HasIndex(e => e.Context, "index_taggings_on_context");

            entity.HasIndex(e => e.TagId, "index_taggings_on_tag_id");

            entity.HasIndex(e => e.TaggableId, "index_taggings_on_taggable_id");

            entity.HasIndex(e => new { e.TaggableId, e.TaggableType, e.Context }, "index_taggings_on_taggable_id_and_taggable_type_and_context");

            entity.HasIndex(e => e.TaggableType, "index_taggings_on_taggable_type");

            entity.HasIndex(e => e.TaggerId, "index_taggings_on_tagger_id");

            entity.HasIndex(e => new { e.TaggerId, e.TaggerType }, "index_taggings_on_tagger_id_and_tagger_type");

            entity.HasIndex(e => new { e.TagId, e.TaggableId, e.TaggableType, e.Context, e.TaggerId, e.TaggerType }, "taggings_idx").IsUnique();

            entity.HasIndex(e => new { e.TaggableId, e.TaggableType, e.TaggerId, e.Context }, "taggings_idy");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Context)
                .HasMaxLength(128)
                .HasColumnName("context");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.TagId).HasColumnName("tag_id");
            entity.Property(e => e.TaggableId).HasColumnName("taggable_id");
            entity.Property(e => e.TaggableType)
                .HasColumnType("character varying")
                .HasColumnName("taggable_type");
            entity.Property(e => e.TaggerId).HasColumnName("tagger_id");
            entity.Property(e => e.TaggerType)
                .HasColumnType("character varying")
                .HasColumnName("tagger_type");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("teams_pkey");

            entity.ToTable("teams");

            entity.HasIndex(e => e.AccountId, "index_teams_on_account_id");

            entity.HasIndex(e => new { e.Name, e.AccountId }, "index_teams_on_name_and_account_id").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.AllowAutoAssign)
                .HasDefaultValue(true)
                .HasColumnName("allow_auto_assign");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<TeamMember>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("team_members_pkey");

            entity.ToTable("team_members");

            entity.HasIndex(e => e.TeamId, "index_team_members_on_team_id");

            entity.HasIndex(e => new { e.TeamId, e.UserId }, "index_team_members_on_team_id_and_user_id").IsUnique();

            entity.HasIndex(e => e.UserId, "index_team_members_on_user_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.TeamId).HasColumnName("team_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.UserId).HasColumnName("user_id");
        });

        modelBuilder.Entity<TelegramBot>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("telegram_bots_pkey");

            entity.ToTable("telegram_bots");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.AuthKey)
                .HasColumnType("character varying")
                .HasColumnName("auth_key");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_pkey");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "index_users_on_email");

            entity.HasIndex(e => e.PubsubToken, "index_users_on_pubsub_token").IsUnique();

            entity.HasIndex(e => e.ResetPasswordToken, "index_users_on_reset_password_token").IsUnique();

            entity.HasIndex(e => new { e.Uid, e.Provider }, "index_users_on_uid_and_provider").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Availability)
                .HasDefaultValue(0)
                .HasColumnName("availability");
            entity.Property(e => e.ConfirmationSentAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("confirmation_sent_at");
            entity.Property(e => e.ConfirmationToken)
                .HasColumnType("character varying")
                .HasColumnName("confirmation_token");
            entity.Property(e => e.ConfirmedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("confirmed_at");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.CurrentSignInAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("current_sign_in_at");
            entity.Property(e => e.CurrentSignInIp)
                .HasColumnType("character varying")
                .HasColumnName("current_sign_in_ip");
            entity.Property(e => e.CustomAttributes)
                .HasDefaultValueSql("'{}'::jsonb")
                .HasColumnType("jsonb")
                .HasColumnName("custom_attributes");
            entity.Property(e => e.DisplayName)
                .HasColumnType("character varying")
                .HasColumnName("display_name");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.EncryptedPassword)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("encrypted_password");
            entity.Property(e => e.LastSignInAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("last_sign_in_at");
            entity.Property(e => e.LastSignInIp)
                .HasColumnType("character varying")
                .HasColumnName("last_sign_in_ip");
            entity.Property(e => e.MessageSignature).HasColumnName("message_signature");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Provider)
                .HasDefaultValueSql("'email'::character varying")
                .HasColumnType("character varying")
                .HasColumnName("provider");
            entity.Property(e => e.PubsubToken)
                .HasColumnType("character varying")
                .HasColumnName("pubsub_token");
            entity.Property(e => e.RememberCreatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("remember_created_at");
            entity.Property(e => e.ResetPasswordSentAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("reset_password_sent_at");
            entity.Property(e => e.ResetPasswordToken)
                .HasColumnType("character varying")
                .HasColumnName("reset_password_token");
            entity.Property(e => e.SignInCount)
                .HasDefaultValue(0)
                .HasColumnName("sign_in_count");
            entity.Property(e => e.Tokens)
                .HasColumnType("json")
                .HasColumnName("tokens");
            entity.Property(e => e.Type)
                .HasColumnType("character varying")
                .HasColumnName("type");
            entity.Property(e => e.UiSettings)
                .HasDefaultValueSql("'{}'::jsonb")
                .HasColumnType("jsonb")
                .HasColumnName("ui_settings");
            entity.Property(e => e.Uid)
                .HasDefaultValueSql("''::character varying")
                .HasColumnType("character varying")
                .HasColumnName("uid");
            entity.Property(e => e.UnconfirmedEmail)
                .HasColumnType("character varying")
                .HasColumnName("unconfirmed_email");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("updated_at");
        });

        modelBuilder.Entity<Webhook>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("webhooks_pkey");

            entity.ToTable("webhooks");

            entity.HasIndex(e => new { e.AccountId, e.Url }, "index_webhooks_on_account_id_and_url").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.InboxId).HasColumnName("inbox_id");
            entity.Property(e => e.Subscriptions)
                .HasDefaultValueSql("'[\"conversation_status_changed\", \"conversation_updated\", \"conversation_created\", \"contact_created\", \"contact_updated\", \"message_created\", \"message_updated\", \"webwidget_triggered\"]'::jsonb")
                .HasColumnType("jsonb")
                .HasColumnName("subscriptions");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
            entity.Property(e => e.Url)
                .HasColumnType("character varying")
                .HasColumnName("url");
            entity.Property(e => e.WebhookType)
                .HasDefaultValue(0)
                .HasColumnName("webhook_type");
        });

        modelBuilder.Entity<WorkingHour>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("working_hours_pkey");

            entity.ToTable("working_hours");

            entity.HasIndex(e => e.AccountId, "index_working_hours_on_account_id");

            entity.HasIndex(e => e.InboxId, "index_working_hours_on_inbox_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.CloseHour).HasColumnName("close_hour");
            entity.Property(e => e.CloseMinutes).HasColumnName("close_minutes");
            entity.Property(e => e.ClosedAllDay)
                .HasDefaultValue(false)
                .HasColumnName("closed_all_day");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("created_at");
            entity.Property(e => e.DayOfWeek).HasColumnName("day_of_week");
            entity.Property(e => e.InboxId).HasColumnName("inbox_id");
            entity.Property(e => e.OpenAllDay)
                .HasDefaultValue(false)
                .HasColumnName("open_all_day");
            entity.Property(e => e.OpenHour).HasColumnName("open_hour");
            entity.Property(e => e.OpenMinutes).HasColumnName("open_minutes");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("timestamp(6) without time zone")
                .HasColumnName("updated_at");
        });
        modelBuilder.HasSequence("camp_dpid_seq_1");
        modelBuilder.HasSequence("camp_dpid_seq_2");
        modelBuilder.HasSequence("camp_dpid_seq_3");
        modelBuilder.HasSequence("conv_dpid_seq_1");
        modelBuilder.HasSequence("conv_dpid_seq_2");
        modelBuilder.HasSequence("conv_dpid_seq_3");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
