using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Controls.Extensions
{
    public static class VisualTreeHelperExtensions
    {
        public static IEnumerable<DependencyObject> GetAncestors(this DependencyObject start, bool includeStart = false)
        {
            if (start == null)
            {
                yield break;
            }

            if (includeStart)
            {
                yield return start;
            }

            var parent = VisualTreeHelper.GetParent(start);

            while (parent != null)
            {
                yield return parent;
                parent = VisualTreeHelper.GetParent(parent);
            }
        }

        public static IEnumerable<T> GetAncestorsOfType<T>(this DependencyObject start) where T : DependencyObject
        {
            return start.GetAncestors().OfType<T>();
        }

        public static IEnumerable<DependencyObject> GetChildren(this DependencyObject parent)
        {
            if (parent == null)
            {
                yield break;
            }

            var popup = parent as Popup;

            if (popup?.Child != null)
            {
                yield return popup.Child;
                yield break;
            }

            var count = VisualTreeHelper.GetChildrenCount(parent);

            for (var i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                yield return child;
            }
        }

        public static IEnumerable<DependencyObject> GetDescendants(this DependencyObject start, bool includeStart = false)
        {
            if (start == null)
            {
                yield break;
            }

            if (includeStart)
            {
                yield return start;
            }

            var queue = new Queue<DependencyObject>();

            var popup = start as Popup;

            if (popup != null)
            {
                if (popup.Child != null)
                {
                    queue.Enqueue(popup.Child);
                    yield return popup.Child;
                }
            }
            else
            {
                int childrenCount;

                try
                {
                    if (start is UIElement)
                    {
                        childrenCount = VisualTreeHelper.GetChildrenCount(start);
                    }
                    else
                    {
                        childrenCount = 0;
                    }
                }
                catch (Exception)
                {
                    childrenCount = 0;
                }

                for (var i = 0; i < childrenCount; i++)
                {
                    var child = VisualTreeHelper.GetChild(start, i);
                    queue.Enqueue(child);
                    yield return child;
                }
            }

            while (queue.Count > 0)
            {
                var parent = queue.Dequeue();

                popup = parent as Popup;

                if (popup != null)
                {
                    if (popup.Child != null)
                    {
                        queue.Enqueue(popup.Child);
                        yield return popup.Child;
                    }
                }
                else
                {
                    int childrenCount;

                    try
                    {
                        childrenCount = VisualTreeHelper.GetChildrenCount(parent);
                    }
                    catch (Exception)
                    {
                        childrenCount = 0;
                    }

                    for (var i = 0; i < childrenCount; i++)
                    {
                        var child = VisualTreeHelper.GetChild(parent, i);
                        yield return child;
                        queue.Enqueue(child);
                    }
                }
            }
        }

        public static IEnumerable<T> GetDescendantsOfType<T>(this DependencyObject start) where T : DependencyObject
        {
            return start.GetDescendants().OfType<T>();
        }

        public static T GetFirstAncestorOfType<T>(this DependencyObject start) where T : DependencyObject
        {
            return start.GetAncestorsOfType<T>().FirstOrDefault();
        }

        public static T GetFirstDescendantOfType<T>(this DependencyObject start) where T : DependencyObject
        {
            return start.GetDescendantsOfType<T>().FirstOrDefault();
        }

        public static UIElement GetRealWindowRoot(Window window = null)
        {
            if (window == null)
            {
                window = Application.Current.MainWindow;
            }

            if (window == null)
            {
                return null;
            }

            var root = window.Content as FrameworkElement;

            var ancestors = root?.GetAncestors().ToList();

            if (ancestors?.Count > 0)
            {
                root = (FrameworkElement)ancestors[ancestors.Count - 1];
            }

            return root;
        }

        public static IEnumerable<DependencyObject> GetSiblings(this DependencyObject start)
        {
            if (start == null
                )
            {
                yield break;
            }

            var parent = VisualTreeHelper.GetParent(start);

            if (parent == null)
            {
                yield return start;
            }
            else
            {
                var count = VisualTreeHelper.GetChildrenCount(parent);

                for (var i = 0; i < count; i++)
                {
                    var child = VisualTreeHelper.GetChild(parent, i);
                    yield return child;
                }
            }
        }

        public static bool IsInVisualTree(this DependencyObject dob)
        {
            var isInDesignMode = (bool)DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof(DependencyObject)).DefaultValue;
            if (isInDesignMode)
            {
                return false;
            }

            if (Application.Current.MainWindow == null)
            {
                return false;
            }

            var root = GetRealWindowRoot();

            return root != null && dob.GetAncestors(includeStart: true).Contains(root);
        }
    }
}