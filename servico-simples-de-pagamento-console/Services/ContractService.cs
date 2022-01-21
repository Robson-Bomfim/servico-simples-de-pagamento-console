using servico_simples_de_pagamento_console.Entities;
using servico_simples_de_pagamento_console.Services.Interfaces;

namespace servico_simples_de_pagamento_console.Services
{
    public class ContractService
    {
        private IOnlinePaymentService _onlinePaymentService;

        public ContractService(IOnlinePaymentService onlinePaymentService) {
            _onlinePaymentService = onlinePaymentService;
        }

        public void ProcessContract(Contract contract, int months) {
            double basicQuota = contract.TotalValue / months;
            for (int i = 1; i <= months; i++) {
                DateTime date = contract.Date.AddMonths(i);
                double updatedQuota = basicQuota + _onlinePaymentService.Interest(basicQuota, i);
                double fullQuota =  updatedQuota + _onlinePaymentService.PaymentFee(updatedQuota);
                contract.AddInstallment(new Installment(date, fullQuota));
            }
        }
    }
}