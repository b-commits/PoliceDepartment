"use client";

import type { ReactNode } from "react";
import { AlertTriangle } from "lucide-react";
import { Modal } from "@/components/ui/Modal";
import { Button } from "@/components/ui/Button";
import type { PoliceOfficer } from "@/types/officer";

interface DeleteOfficerDialogProps {
  isOpen: boolean;
  onClose: () => void;
  officer: PoliceOfficer | null;
  onConfirm: () => void;
  isDeleting: boolean;
}

export function DeleteOfficerDialog({
  isOpen,
  onClose,
  officer,
  onConfirm,
  isDeleting,
}: DeleteOfficerDialogProps): ReactNode {
  if (!officer) {
    return null;
  }

  return (
    <Modal isOpen={isOpen} onClose={onClose} title="Delete Officer">
      <div className="space-y-4">
        <div className="flex items-start gap-3">
          <div className="flex h-10 w-10 shrink-0 items-center justify-center rounded-full bg-red-100 dark:bg-red-900/30">
            <AlertTriangle className="h-5 w-5 text-red-600 dark:text-red-400" />
          </div>
          <div>
            <p className="text-sm text-slate-700 dark:text-slate-300">
              Are you sure you want to delete{" "}
              <span className="font-semibold">
                {officer.firstName} {officer.lastName}
              </span>
              ? This action cannot be undone.
            </p>
          </div>
        </div>
        <div className="flex justify-end gap-3">
          <Button
            type="button"
            variant="secondary"
            onClick={onClose}
            disabled={isDeleting}
          >
            Cancel
          </Button>
          <Button
            type="button"
            variant="danger"
            onClick={onConfirm}
            isLoading={isDeleting}
          >
            Delete
          </Button>
        </div>
      </div>
    </Modal>
  );
}