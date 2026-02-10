"use client";

import { useState, useCallback } from "react";
import type { ReactNode } from "react";
import { Plus } from "lucide-react";
import { useOfficers } from "@/hooks/useOfficers";
import { useCreateOfficer } from "@/hooks/useCreateOfficer";
import { useUpdateOfficer } from "@/hooks/useUpdateOfficer";
import { useDeleteOfficer } from "@/hooks/useDeleteOfficer";
import { OfficersTable } from "@/components/officers/OfficersTable";
import { OfficerFormModal } from "@/components/officers/OfficerFormModal";
import { DeleteOfficerDialog } from "@/components/officers/DeleteOfficerDialog";
import { Button } from "@/components/ui/Button";
import { useToast } from "@/components/ui/Toast";
import { ApiClientError } from "@/lib/api-client";
import type { PoliceOfficer } from "@/types/officer";
import type { OfficerFormData } from "@/lib/validators";

function getErrorMessage(error: Error): string {
  if (error instanceof ApiClientError && error.status === 401) {
    return "Unauthorized. Please sign in to perform this action.";
  }
  return error.message || "An unexpected error occurred.";
}

export default function OfficersPage(): ReactNode {
  const { data: officers, isLoading, error } = useOfficers();
  const { toast } = useToast();

  const createMutation = useCreateOfficer();
  const updateMutation = useUpdateOfficer();
  const deleteMutation = useDeleteOfficer();

  const [isFormOpen, setIsFormOpen] = useState<boolean>(false);
  const [editingOfficer, setEditingOfficer] = useState<
    PoliceOfficer | undefined
  >(undefined);
  const [deletingOfficer, setDeletingOfficer] =
    useState<PoliceOfficer | null>(null);

  const handleCreate = useCallback((): void => {
    setEditingOfficer(undefined);
    setIsFormOpen(true);
  }, []);

  const handleEdit = useCallback((officer: PoliceOfficer): void => {
    setEditingOfficer(officer);
    setIsFormOpen(true);
  }, []);

  const handleDelete = useCallback((officer: PoliceOfficer): void => {
    setDeletingOfficer(officer);
  }, []);

  const handleFormSubmit = useCallback(
    (data: OfficerFormData): void => {
      if (editingOfficer) {
        updateMutation.mutate(
          {
            id: editingOfficer.id,
            data: {
              firstName: data.firstName,
              lastName: data.lastName,
              badgeNumber: data.badgeNumber,
              birthDate: data.birthDate,
            },
          },
          {
            onSuccess: (): void => {
              setIsFormOpen(false);
              setEditingOfficer(undefined);
              toast("Officer updated successfully.", "success");
            },
            onError: (error: Error): void => {
              toast(getErrorMessage(error), "error");
            },
          }
        );
      } else {
        createMutation.mutate(
          {
            id: crypto.randomUUID(),
            firstName: data.firstName,
            lastName: data.lastName,
            badgeNumber: data.badgeNumber,
            birthDate: data.birthDate,
          },
          {
            onSuccess: (): void => {
              setIsFormOpen(false);
              toast("Officer created successfully.", "success");
            },
            onError: (error: Error): void => {
              toast(getErrorMessage(error), "error");
            },
          }
        );
      }
    },
    [editingOfficer, createMutation, updateMutation, toast]
  );

  const handleDeleteConfirm = useCallback((): void => {
    if (!deletingOfficer) return;

    deleteMutation.mutate(deletingOfficer.id, {
      onSuccess: (): void => {
        setDeletingOfficer(null);
        toast("Officer deleted successfully.", "success");
      },
      onError: (error: Error): void => {
        toast(getErrorMessage(error), "error");
      },
    });
  }, [deletingOfficer, deleteMutation, toast]);

  const handleFormClose = useCallback((): void => {
    setIsFormOpen(false);
    setEditingOfficer(undefined);
  }, []);

  const handleDeleteClose = useCallback((): void => {
    setDeletingOfficer(null);
  }, []);

  if (isLoading) {
    return (
      <div className="flex items-center justify-center py-20">
        <div className="text-center space-y-3">
          <div className="mx-auto h-8 w-8 animate-spin rounded-full border-4 border-slate-200 border-t-blue-600 dark:border-slate-700 dark:border-t-blue-400" />
          <p className="text-sm text-slate-500 dark:text-slate-400">
            Loading officers...
          </p>
        </div>
      </div>
    );
  }

  if (error) {
    return (
      <div className="rounded-xl border border-red-200 bg-red-50 p-6 dark:border-red-900/50 dark:bg-red-900/10">
        <p className="text-sm text-red-700 dark:text-red-400">
          Failed to load officers: {error.message}
        </p>
      </div>
    );
  }

  return (
    <div className="space-y-6">
      <div className="flex items-center justify-between">
        <div>
          <h2 className="text-2xl font-bold text-slate-900 dark:text-slate-100">
            Officers
          </h2>
          <p className="mt-1 text-sm text-slate-500 dark:text-slate-400">
            Manage police officers in the department.
          </p>
        </div>
        <Button onClick={handleCreate}>
          <Plus className="h-4 w-4" />
          Add Officer
        </Button>
      </div>

      <OfficersTable
        data={officers ?? []}
        onEdit={handleEdit}
        onDelete={handleDelete}
      />

      <OfficerFormModal
        isOpen={isFormOpen}
        onClose={handleFormClose}
        officer={editingOfficer}
        onSubmit={handleFormSubmit}
        isSubmitting={createMutation.isPending || updateMutation.isPending}
      />

      <DeleteOfficerDialog
        isOpen={deletingOfficer !== null}
        onClose={handleDeleteClose}
        officer={deletingOfficer}
        onConfirm={handleDeleteConfirm}
        isDeleting={deleteMutation.isPending}
      />
    </div>
  );
}