﻿using Microsoft.AspNetCore.Mvc;

namespace FUNewsManagement_Assigment01.Component.AdminAction
{
    public class StaffAction : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
