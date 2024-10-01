﻿using Walgelijk;
using Walgelijk.Onion;
using Walgelijk.SimpleDrawing;

namespace MIR;

/// <summary>
/// Manage <see cref="ConfirmationDialogComponent"/>.
/// </summary>
public class ConfirmationDialogSystem : Walgelijk.System
{
    public override void Update()
    {
        foreach (var item in Scene.GetAllComponentsOfType<ConfirmationDialogComponent>())
        {
            bool isOpen = true;

            var estimatedHeight = Draw.CalculateTextHeight(item.Message, 370) + 100;

            Ui.Layout.Order(1000).Size(370, float.Min(190, estimatedHeight)).Center();
            Ui.Theme.Background((Appearance)Colors.Black).Once();
            Ui.StartDragWindow(item.Title, ref isOpen, item.Entity);
            {
                Ui.Layout.PreferredSize().StickLeft().StickTop().FitWidth();
                Ui.TextRect(item.Message, HorizontalTextAlign.Center, VerticalTextAlign.Middle);

                Ui.Layout.FitWidth(false).Height(32).StickBottom().Move(0, Ui.Theme.Base.Padding).EnqueueLayout(new DistributeChildrenLayout());
                Ui.StartGroup(false);
                {
                    Ui.Layout.FitContainer(1, 1, false);
                    if (Ui.ClickButton("No"))
                        isOpen = false;

                    Ui.Layout.FitContainer(1, 1, false);
                    Ui.Theme.Foreground((Appearance)Colors.White).Text(new(Colors.Black, Colors.Red)).Once();
                    if (Ui.ClickButton("Yes"))
                    {
                        isOpen = false;
                        item.OnAgree();
                    }
                }
                Ui.End();
            }
            Ui.End();

            if (!isOpen)
            {
                if (item.RemoveEntityOnClose)
                    Scene.RemoveEntity(item.Entity);
                else
                    Scene.DetachComponent<ConfirmationDialogComponent>(item.Entity);
            }
        }
    }
}