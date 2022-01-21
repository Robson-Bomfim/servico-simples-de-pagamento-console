namespace servico_simples_de_pagamento_console.Services.Interfaces
{
    public interface IOnlinePaymentService
    {
        double PaymentFee(double amount);
        double Interest(double amount, int months);
    }
}