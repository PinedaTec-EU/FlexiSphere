using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlexiSphere;

public interface IFlexiSphere : IFlexiSphereComponent
{
    /// <summary>
    /// Event triggered when the TimeSphere is canceled.
    /// </summary>
    event FlexiSphereHandler? OnCanceled;

    /// <summary>
    /// Event triggered when the TimeSphere has completed a flow. 
    /// </summary>
    event FlexiSphereHandler? OnCompleted;

    /// <summary>
    /// Event triggered when the TimeSphere is triggered.
    /// </summary>
    event FlexiSphereHandler? OnTriggered;

    /// <summary>
    /// Event triggered when the TimeSphere is faulted.
    /// </summary>
    event FlexiSphereExceptionHandler<Exception>? OnFaulted;

    /// <summary>
    /// Event triggered before a job is executed.
    /// </summary>
    event FlexiSphereHandler? OnBeforeJobExecuted;

    /// <summary>
    /// Event triggered after a job is executed.
    /// </summary>
    event FlexiSphereHandler? OnAfterJobExecuted;

    /// <summary>
    /// Gets the counter of the TimeSphere executions.
    /// </summary>
    int Counter { get; }

    /// <summary>
    /// Gets the last time the TimeSphere was triggered.
    /// </summary>
    DateTime? LastTriggered { get; }

    /// <summary>
    /// Gets the list of TimeSphere triggers.
    /// </summary>
    IReadOnlyCollection<IFlexiSphereTrigger> Triggers { get; }

    /// <summary>
    /// Gets the list of TimeSphere jobs.
    /// </summary>
    IReadOnlyCollection<IFlexiSphereJob> Jobs { get; }

    /// <summary>
    /// Adds a trigger to the TimeSphere.
    /// </summary>
    /// <param name="trigger"></param>
    void AddTrigger(IFlexiSphereTrigger trigger);

    /// <summary>
    /// Adds a job to the TimeSphere.
    /// </summary>
    /// <param name="job"></param>
    void AddJob(IFlexiSphereJob job);

    /// <summary>
    /// Starts the TimeSphere.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task StartAsync(IFlexiSphereContext? context = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Stops the TimeSphere.
    /// </summary>
    /// <param name="issue"></param>
    /// <param name="context"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task StopAsync(string issue, IFlexiSphereContext? context = null, CancellationToken cancellationToken = default);
}
