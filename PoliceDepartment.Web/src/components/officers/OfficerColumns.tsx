"use client";

import { createColumnHelper } from "@tanstack/react-table";
import type { ColumnDef } from "@tanstack/react-table";
import { Pencil, Trash2 } from "lucide-react";
import type { PoliceOfficer } from "@/types/officer";
import { Badge } from "@/components/ui/Badge";

interface OfficerColumnsOptions {
  onEdit: (officer: PoliceOfficer) => void;
  onDelete: (officer: PoliceOfficer) => void;
}

const columnHelper = createColumnHelper<PoliceOfficer>();

export function getOfficerColumns({
  onEdit,
  onDelete,
}: OfficerColumnsOptions): ColumnDef<PoliceOfficer, unknown>[] {
  return [
    columnHelper.accessor("firstName", {
      header: "First Name",
      cell: (info) => (
        <span className="font-medium text-slate-900 dark:text-slate-100">
          {info.getValue()}
        </span>
      ),
    }) as ColumnDef<PoliceOfficer, unknown>,
    columnHelper.accessor("lastName", {
      header: "Last Name",
      cell: (info) => (
        <span className="text-slate-700 dark:text-slate-300">
          {info.getValue()}
        </span>
      ),
    }) as ColumnDef<PoliceOfficer, unknown>,
    columnHelper.accessor(
      (row: PoliceOfficer): string => row.badgeNumber.value,
      {
        id: "badgeNumber",
        header: "Badge Number",
        cell: (info) => <Badge variant="blue">{info.getValue()}</Badge>,
      }
    ) as ColumnDef<PoliceOfficer, unknown>,
    columnHelper.accessor(
      (row: PoliceOfficer): string => row.birthDate.value,
      {
        id: "birthDate",
        header: "Birth Date",
        cell: (info) => {
          const value: string = info.getValue();
          const formatted: string = new Date(value).toLocaleDateString(
            "en-US",
            {
              year: "numeric",
              month: "short",
              day: "numeric",
            }
          );
          return (
            <span className="text-slate-600 dark:text-slate-400">
              {formatted}
            </span>
          );
        },
      }
    ) as ColumnDef<PoliceOfficer, unknown>,
    columnHelper.display({
      id: "actions",
      header: "",
      cell: ({ row }) => (
        <div className="flex items-center justify-end gap-1">
          <button
            onClick={(): void => onEdit(row.original)}
            className="rounded-lg p-1.5 text-slate-400 hover:bg-slate-100 hover:text-blue-600 dark:hover:bg-slate-700 dark:hover:text-blue-400 transition-colors"
            aria-label={`Edit ${row.original.firstName} ${row.original.lastName}`}
          >
            <Pencil className="h-4 w-4" />
          </button>
          <button
            onClick={(): void => onDelete(row.original)}
            className="rounded-lg p-1.5 text-slate-400 hover:bg-slate-100 hover:text-red-600 dark:hover:bg-slate-700 dark:hover:text-red-400 transition-colors"
            aria-label={`Delete ${row.original.firstName} ${row.original.lastName}`}
          >
            <Trash2 className="h-4 w-4" />
          </button>
        </div>
      ),
    }) as ColumnDef<PoliceOfficer, unknown>,
  ];
}