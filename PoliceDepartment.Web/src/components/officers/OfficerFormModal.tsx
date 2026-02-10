"use client";

import type { ReactNode } from "react";
import { Modal } from "@/components/ui/Modal";
import { OfficerForm } from "./OfficerForm";
import type { OfficerFormData } from "@/lib/validators";
import type { PoliceOfficer } from "@/types/officer";

interface OfficerFormModalProps {
  isOpen: boolean;
  onClose: () => void;
  officer?: PoliceOfficer;
  onSubmit: (data: OfficerFormData) => void;
  isSubmitting: boolean;
}

export function OfficerFormModal({
  isOpen,
  onClose,
  officer,
  onSubmit,
  isSubmitting,
}: OfficerFormModalProps): ReactNode {
  const title: string = officer ? "Edit Officer" : "Add New Officer";

  return (
    <Modal isOpen={isOpen} onClose={onClose} title={title}>
      <OfficerForm
        officer={officer}
        onSubmit={onSubmit}
        onCancel={onClose}
        isSubmitting={isSubmitting}
      />
    </Modal>
  );
}