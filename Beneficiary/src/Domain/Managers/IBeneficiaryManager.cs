using System.Threading.Tasks;
using Beneficiary.Domain.DTOs;

namespace Beneficiary.Domain.Managers
{
#nullable enable
    public interface IBeneficiaryManager
    {
        /// <summary>
        /// Registers a new beneficiary in the system
        /// </summary>
        /// <param name="registrationDto">The beneficiary registration information</param>
        /// <param name="dryRun">If true, performs validation only without committing to database</param>
        /// <param name="simulateFailures">If true, includes random failure simulation (default: true for non-dryRun, false for dryRun)</param>
        /// <returns>The result of the registration operation</returns>
        Task<BeneficiaryRegistrationResult> RegisterBeneficiaryAsync(
            BeneficiaryRegistrationDto registrationDto, 
            bool dryRun = false,
            bool? simulateFailures = null);
    }
}