namespace SDTFramework.Utils.Enums
{
    public enum AuditFunctionality
    {
        [AuditNomeKey("auditFunctionalityCalendario")]
        Calendario = 4,
        [AuditNomeKey("auditFunctionalityDiaSemanaCalendario")]
        DiaSemanaCalendario = 5,
        [AuditNomeKey("auditFunctionalityFeriado")]
        Feriado = 6,
        [AuditNomeKey("auditFunctionalityMovimento")]
        Movimento = 7,
        [AuditNomeKey("auditFunctionalityLeituraArquivo")]
        LeituraArquivo = 8,
        [AuditNomeKey("auditFunctionalityPais")]
        Pais = 9,
        [AuditNomeKey("auditFunctionalityServico")]
        Servico = 10,
        [AuditNomeKey("auditFunctionalityServicoNavio")]
        ServicoNavio = 11,
        [AuditNomeKey("auditFunctionalityServicoCalendario")]
        ServicoCalendario = 12,
        [AuditNomeKey("auditFunctionalityIntervaloModificado")]
        IntervaloModificado = 13,
        [AuditNomeKey("auditFunctionalityTipoDocumentoCalendario")]
        TipoDocumentoCalendario = 14,
        [AuditNomeKey("auditFunctionalityTipoTelefone")]
        TipoTelefone = 15,
        [AuditNomeKey("auditFunctionalityEmpresaAssociada")]
        EmpresaAssociada = 16,
        [AuditNomeKey("auditFunctionalityEdicaoStatusProgramacaoNavio")]
        EdicaoStatusProgramacaoNavio = 17,
        [AuditNomeKey("auditFunctionalityConfiguracaoEmail")]
        ConfiguracaoEmail = 18,
        [AuditNomeKey("auditFuncionalityStatus")]
        Status = 19,
        [AuditNomeKey("auditFunctionalityPublicacaoStatusProgramacaoNavio")]
        PublicacaoStatusProgramacaoNavio = 20
    }
}