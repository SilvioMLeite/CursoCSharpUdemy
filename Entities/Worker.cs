using System.Collections.Generic;
using Aula118_Exercicios_propostos_PARTE1.Entities.Enums;

namespace Aula118_Exercicios_propostos_PARTE1.Entities
{
    class Worker
    {
        public string Name { get; set; }
        public WorkLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        
        //Lembrete - Após criada deve iniciar a lista para garantir que ela não seja nula
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();

        public Worker()
        {
                
        }

        //Lembrete - Não é usual passar uma lista em um construtor de objetos a lista inicia vazia e depois adcionando objetos conforme necessidade
        public Worker(string name, WorkLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        //Descrição - Este método recebe um contrato como parâmetro de entrada e vai adcionar o contrato dentro da lista de contratos do trabalhador
        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);
        }

        //Descrição - Este método recebe um contrato como parâmetro de entrada e vai remover o contrato de dentro da lista de contratos do trabalhador
        public void RemoveContract(HourContract contract){
            Contracts.Remove(contract);
        }

        //Descrição - Este método totaliza quanto o trabalhador recebeu com base nos parâmetros de entrada ano e mês
        public double Income(int year, int month)
        {
            double sum = BaseSalary;

            //Descrição - Percorre a lista acumulando na variavél sum a soma desses contratos quando o mês e o ano baterem com os valores informados na entrada de parâmetros
            foreach( HourContract contract in Contracts)
            {
                if ( contract.Date.Year == year && contract.Date.Month == month)
                {
                    sum += contract.totalValue();
                }
            }
            return sum;
        }
    }
}
