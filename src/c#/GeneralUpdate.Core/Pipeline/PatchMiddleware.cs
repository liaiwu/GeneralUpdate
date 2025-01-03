﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using GeneralUpdate.Common.FileBasic;
using GeneralUpdate.Common.Internal;
using GeneralUpdate.Common.Internal.Event;
using GeneralUpdate.Common.Internal.Pipeline;
using GeneralUpdate.Differential;

namespace GeneralUpdate.Core.Pipeline;

public class PatchMiddleware : IMiddleware
{
    public async Task InvokeAsync(PipelineContext context)
    {
        try
        {
            var sourcePath = context.Get<string>("SourcePath");
            var targetPath = context.Get<string>("PatchPath");
            await DifferentialCore.Instance?.Dirty(sourcePath, targetPath);
        }
        catch (Exception exception)
        {
            Debug.WriteLine(exception.Message);
            EventManager.Instance.Dispatch(this, new ExceptionEventArgs(exception, exception.Message));
        }
    }
}