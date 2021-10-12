namespace BugFeed.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comentarios",
                c => new
                    {
                        ComentarioId = c.Int(nullable: false, identity: true),
                        Conteudo = c.String(nullable: false),
                        DataHora = c.DateTime(nullable: false),
                        Apagado = c.Boolean(nullable: false),
                        Data = c.DateTime(nullable: false),
                        UltimaRevisao = c.DateTime(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Programa_ProgramaRecompensasId = c.Int(),
                        Relatorio_RelatorioBugId = c.Int(),
                        Usuario_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ComentarioId)
                .ForeignKey("dbo.ProgramaRecompensas", t => t.Programa_ProgramaRecompensasId)
                .ForeignKey("dbo.RelatorioBugs", t => t.Relatorio_RelatorioBugId)
                .ForeignKey("dbo.AspNetUsers", t => t.Usuario_Id, cascadeDelete: true)
                .Index(t => t.Programa_ProgramaRecompensasId)
                .Index(t => t.Relatorio_RelatorioBugId)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Nome = c.String(),
                        Sobrenome = c.String(),
                        Ativo = c.Boolean(),
                        DataNascimento = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Funcionarios",
                c => new
                    {
                        FuncionarioId = c.Int(nullable: false, identity: true),
                        Grupo_GrupoFuncionariosId = c.Int(nullable: false),
                        Usuario_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.FuncionarioId)
                .ForeignKey("dbo.GrupoFuncionarios", t => t.Grupo_GrupoFuncionariosId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Usuario_Id)
                .Index(t => t.Grupo_GrupoFuncionariosId)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.GrupoFuncionarios",
                c => new
                    {
                        GrupoFuncionariosId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Empresa_EmpresaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GrupoFuncionariosId)
                .ForeignKey("dbo.Empresas", t => t.Empresa_EmpresaId, cascadeDelete: true)
                .Index(t => t.Empresa_EmpresaId);
            
            CreateTable(
                "dbo.Empresas",
                c => new
                    {
                        EmpresaId = c.Int(nullable: false, identity: true),
                        Site = c.String(nullable: false, maxLength: 100),
                        Nome = c.String(nullable: false),
                        CNPJ = c.String(),
                        Verificada = c.Boolean(nullable: false),
                        Endereco_EnderecoId = c.Int(),
                    })
                .PrimaryKey(t => t.EmpresaId)
                .ForeignKey("dbo.Enderecoes", t => t.Endereco_EnderecoId)
                .Index(t => t.Endereco_EnderecoId);
            
            CreateTable(
                "dbo.Enderecoes",
                c => new
                    {
                        EnderecoId = c.Int(nullable: false, identity: true),
                        Destinatario = c.String(nullable: false),
                        Organizacao = c.String(),
                        Linha1 = c.String(nullable: false),
                        Linha2 = c.String(),
                        Linha3 = c.String(),
                        Cidade = c.String(nullable: false, maxLength: 50),
                        Bairro = c.String(nullable: false, maxLength: 30),
                        CEP = c.Int(nullable: false),
                        Estado = c.String(nullable: false, maxLength: 50),
                        Pais = c.String(nullable: false, maxLength: 2),
                    })
                .PrimaryKey(t => t.EnderecoId);
            
            CreateTable(
                "dbo.ProgramaRecompensas",
                c => new
                    {
                        ProgramaRecompensasId = c.Int(nullable: false, identity: true),
                        Estado = c.Int(nullable: false),
                        Titulo = c.String(nullable: false),
                        Descricao = c.String(nullable: false),
                        Orcamento = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DataCriacao = c.DateTime(nullable: false),
                        UltimaRevisao = c.DateTime(),
                        Empresa_EmpresaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProgramaRecompensasId)
                .ForeignKey("dbo.Empresas", t => t.Empresa_EmpresaId, cascadeDelete: true)
                .Index(t => t.Empresa_EmpresaId);
            
            CreateTable(
                "dbo.RelatorioBugs",
                c => new
                    {
                        RelatorioBugId = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 150),
                        Descricao = c.String(nullable: false),
                        Impacto = c.String(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Estado = c.Int(nullable: false),
                        Pesquisador_PesquisadorId = c.Int(nullable: false),
                        Programa_ProgramaRecompensasId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RelatorioBugId)
                .ForeignKey("dbo.Pesquisadors", t => t.Pesquisador_PesquisadorId, cascadeDelete: true)
                .ForeignKey("dbo.ProgramaRecompensas", t => t.Programa_ProgramaRecompensasId, cascadeDelete: true)
                .Index(t => t.Pesquisador_PesquisadorId)
                .Index(t => t.Programa_ProgramaRecompensasId);
            
            CreateTable(
                "dbo.Pesquisadors",
                c => new
                    {
                        PesquisadorId = c.Int(nullable: false, identity: true),
                        Endereco_EnderecoId = c.Int(),
                        Usuario_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.PesquisadorId)
                .ForeignKey("dbo.Enderecoes", t => t.Endereco_EnderecoId)
                .ForeignKey("dbo.AspNetUsers", t => t.Usuario_Id)
                .Index(t => t.Endereco_EnderecoId)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.DadosBancarios",
                c => new
                    {
                        DadosBancariosId = c.Int(nullable: false, identity: true),
                        CPF = c.String(nullable: false),
                        Agencia = c.Int(nullable: false),
                        DigitoAgencia = c.Int(nullable: false),
                        Conta = c.Int(nullable: false),
                        DigitoConta = c.Int(nullable: false),
                        Confirmado = c.Boolean(nullable: false),
                        Pesquisador_PesquisadorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DadosBancariosId)
                .ForeignKey("dbo.Pesquisadors", t => t.Pesquisador_PesquisadorId, cascadeDelete: true)
                .Index(t => t.Pesquisador_PesquisadorId);
            
            CreateTable(
                "dbo.Formacaos",
                c => new
                    {
                        FormacaoId = c.Int(nullable: false, identity: true),
                        TipoFormacao = c.Int(nullable: false),
                        Descricao = c.String(nullable: false),
                        Pesquisador_PesquisadorId = c.Int(),
                    })
                .PrimaryKey(t => t.FormacaoId)
                .ForeignKey("dbo.Pesquisadors", t => t.Pesquisador_PesquisadorId)
                .Index(t => t.Pesquisador_PesquisadorId);
            
            CreateTable(
                "dbo.Retiradas",
                c => new
                    {
                        RetiradaId = c.Int(nullable: false, identity: true),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Data = c.DateTime(nullable: false),
                        Estado = c.Int(nullable: false),
                        DadosBancarios_DadosBancariosId = c.Int(nullable: false),
                        Pesquisador_PesquisadorId = c.Int(),
                    })
                .PrimaryKey(t => t.RetiradaId)
                .ForeignKey("dbo.DadosBancarios", t => t.DadosBancarios_DadosBancariosId, cascadeDelete: true)
                .ForeignKey("dbo.Pesquisadors", t => t.Pesquisador_PesquisadorId)
                .Index(t => t.DadosBancarios_DadosBancariosId)
                .Index(t => t.Pesquisador_PesquisadorId);
            
            CreateTable(
                "dbo.Recompensas",
                c => new
                    {
                        RecompensaId = c.Int(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Estado = c.Int(nullable: false),
                        Avaliador_FuncionarioId = c.Int(nullable: false),
                        Pagador_FuncionarioId = c.Int(),
                    })
                .PrimaryKey(t => t.RecompensaId)
                .ForeignKey("dbo.Funcionarios", t => t.Avaliador_FuncionarioId, cascadeDelete: true)
                .ForeignKey("dbo.Funcionarios", t => t.Pagador_FuncionarioId)
                .ForeignKey("dbo.RelatorioBugs", t => t.RecompensaId)
                .Index(t => t.RecompensaId)
                .Index(t => t.Avaliador_FuncionarioId)
                .Index(t => t.Pagador_FuncionarioId);
            
            CreateTable(
                "dbo.Permissaos",
                c => new
                    {
                        PermissaoId = c.Int(nullable: false, identity: true),
                        Perfil = c.Int(nullable: false),
                        GrupoFuncionarios_GrupoFuncionariosId = c.Int(),
                    })
                .PrimaryKey(t => t.PermissaoId)
                .ForeignKey("dbo.GrupoFuncionarios", t => t.GrupoFuncionarios_GrupoFuncionariosId)
                .Index(t => t.GrupoFuncionarios_GrupoFuncionariosId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Comentarios", "Usuario_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Funcionarios", "Usuario_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Funcionarios", "Grupo_GrupoFuncionariosId", "dbo.GrupoFuncionarios");
            DropForeignKey("dbo.Permissaos", "GrupoFuncionarios_GrupoFuncionariosId", "dbo.GrupoFuncionarios");
            DropForeignKey("dbo.GrupoFuncionarios", "Empresa_EmpresaId", "dbo.Empresas");
            DropForeignKey("dbo.Recompensas", "RecompensaId", "dbo.RelatorioBugs");
            DropForeignKey("dbo.Recompensas", "Pagador_FuncionarioId", "dbo.Funcionarios");
            DropForeignKey("dbo.Recompensas", "Avaliador_FuncionarioId", "dbo.Funcionarios");
            DropForeignKey("dbo.RelatorioBugs", "Programa_ProgramaRecompensasId", "dbo.ProgramaRecompensas");
            DropForeignKey("dbo.RelatorioBugs", "Pesquisador_PesquisadorId", "dbo.Pesquisadors");
            DropForeignKey("dbo.Pesquisadors", "Usuario_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Retiradas", "Pesquisador_PesquisadorId", "dbo.Pesquisadors");
            DropForeignKey("dbo.Retiradas", "DadosBancarios_DadosBancariosId", "dbo.DadosBancarios");
            DropForeignKey("dbo.Formacaos", "Pesquisador_PesquisadorId", "dbo.Pesquisadors");
            DropForeignKey("dbo.Pesquisadors", "Endereco_EnderecoId", "dbo.Enderecoes");
            DropForeignKey("dbo.DadosBancarios", "Pesquisador_PesquisadorId", "dbo.Pesquisadors");
            DropForeignKey("dbo.Comentarios", "Relatorio_RelatorioBugId", "dbo.RelatorioBugs");
            DropForeignKey("dbo.ProgramaRecompensas", "Empresa_EmpresaId", "dbo.Empresas");
            DropForeignKey("dbo.Comentarios", "Programa_ProgramaRecompensasId", "dbo.ProgramaRecompensas");
            DropForeignKey("dbo.Empresas", "Endereco_EnderecoId", "dbo.Enderecoes");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Permissaos", new[] { "GrupoFuncionarios_GrupoFuncionariosId" });
            DropIndex("dbo.Recompensas", new[] { "Pagador_FuncionarioId" });
            DropIndex("dbo.Recompensas", new[] { "Avaliador_FuncionarioId" });
            DropIndex("dbo.Recompensas", new[] { "RecompensaId" });
            DropIndex("dbo.Retiradas", new[] { "Pesquisador_PesquisadorId" });
            DropIndex("dbo.Retiradas", new[] { "DadosBancarios_DadosBancariosId" });
            DropIndex("dbo.Formacaos", new[] { "Pesquisador_PesquisadorId" });
            DropIndex("dbo.DadosBancarios", new[] { "Pesquisador_PesquisadorId" });
            DropIndex("dbo.Pesquisadors", new[] { "Usuario_Id" });
            DropIndex("dbo.Pesquisadors", new[] { "Endereco_EnderecoId" });
            DropIndex("dbo.RelatorioBugs", new[] { "Programa_ProgramaRecompensasId" });
            DropIndex("dbo.RelatorioBugs", new[] { "Pesquisador_PesquisadorId" });
            DropIndex("dbo.ProgramaRecompensas", new[] { "Empresa_EmpresaId" });
            DropIndex("dbo.Empresas", new[] { "Endereco_EnderecoId" });
            DropIndex("dbo.GrupoFuncionarios", new[] { "Empresa_EmpresaId" });
            DropIndex("dbo.Funcionarios", new[] { "Usuario_Id" });
            DropIndex("dbo.Funcionarios", new[] { "Grupo_GrupoFuncionariosId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Comentarios", new[] { "Usuario_Id" });
            DropIndex("dbo.Comentarios", new[] { "Relatorio_RelatorioBugId" });
            DropIndex("dbo.Comentarios", new[] { "Programa_ProgramaRecompensasId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Permissaos");
            DropTable("dbo.Recompensas");
            DropTable("dbo.Retiradas");
            DropTable("dbo.Formacaos");
            DropTable("dbo.DadosBancarios");
            DropTable("dbo.Pesquisadors");
            DropTable("dbo.RelatorioBugs");
            DropTable("dbo.ProgramaRecompensas");
            DropTable("dbo.Enderecoes");
            DropTable("dbo.Empresas");
            DropTable("dbo.GrupoFuncionarios");
            DropTable("dbo.Funcionarios");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Comentarios");
        }
    }
}
