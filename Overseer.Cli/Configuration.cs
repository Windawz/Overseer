using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Overseer.Data;

namespace Overseer.Cli;
internal static class Configuration {
    public static readonly string WelcomeMessage =
        "Welcome to Overseer CLI."
        + " Type `help` to view help on available commands.";
    public static readonly string BackendUrl = "https://localhost:5001";
    public static readonly EntityControllerNameMap ControllerNameMap = new(new Dictionary<Type, string> {
        { typeof(Bank), "Banks" },
        { typeof(Body), "Bodies" },
        { typeof(Debt), "Debts" },
        { typeof(RedemptionAttempt), "RedemptionAttempts" },
        { typeof(RedemptionConclusion), "RedemptionConclusions" },
        { typeof(Service), "Services" },
        { typeof(ServiceKind), "ServiceKinds" },
        { typeof(Tax), "Taxes" },
    });
}
