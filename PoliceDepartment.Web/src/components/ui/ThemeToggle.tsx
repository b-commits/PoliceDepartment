"use client";

import { useTheme } from "next-themes";
import { useEffect, useState } from "react";
import type { ReactNode } from "react";
import { Sun, Moon } from "lucide-react";

export function ThemeToggle(): ReactNode {
  const { theme, setTheme } = useTheme();
  const [mounted, setMounted] = useState<boolean>(false);

  useEffect((): void => {
    setMounted(true);
  }, []);

  if (!mounted) {
    return (
      <button
        className="rounded-lg p-2 text-slate-500"
        aria-label="Toggle theme"
      >
        <Sun className="h-5 w-5" />
      </button>
    );
  }

  const isDark: boolean = theme === "dark";

  return (
    <button
      onClick={(): void => setTheme(isDark ? "light" : "dark")}
      className="rounded-lg p-2 text-slate-500 hover:bg-slate-100 hover:text-slate-700 dark:text-slate-400 dark:hover:bg-slate-800 dark:hover:text-slate-200 transition-colors"
      aria-label={isDark ? "Switch to light mode" : "Switch to dark mode"}
    >
      {isDark ? <Sun className="h-5 w-5" /> : <Moon className="h-5 w-5" />}
    </button>
  );
}