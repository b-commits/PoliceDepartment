"use client";

import type { ReactNode } from "react";
import { useForm } from "react-hook-form";
import type { UseFormReturn } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { officerFormSchema } from "@/lib/validators";
import type { OfficerFormData } from "@/lib/validators";
import type { PoliceOfficer } from "@/types/officer";
import { Input } from "@/components/ui/Input";
import { Button } from "@/components/ui/Button";

interface OfficerFormProps {
  officer?: PoliceOfficer;
  onSubmit: (data: OfficerFormData) => void;
  onCancel: () => void;
  isSubmitting: boolean;
}

export function OfficerForm({
  officer,
  onSubmit,
  onCancel,
  isSubmitting,
}: OfficerFormProps): ReactNode {
  const isEditing: boolean = officer !== undefined;

  const form: UseFormReturn<OfficerFormData> = useForm<OfficerFormData>({
    resolver: zodResolver(officerFormSchema),
    defaultValues: {
      firstName: officer?.firstName ?? "",
      lastName: officer?.lastName ?? "",
      badgeNumber: officer?.badgeNumber.value ?? "",
      birthDate: officer?.birthDate.value ?? "",
    },
  });

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = form;

  return (
    <form onSubmit={handleSubmit(onSubmit)} className="space-y-4">
      <Input
        label="First Name"
        placeholder="John"
        error={errors.firstName?.message}
        {...register("firstName")}
      />
      <Input
        label="Last Name"
        placeholder="Doe"
        error={errors.lastName?.message}
        {...register("lastName")}
      />
      <Input
        label="Badge Number"
        placeholder="#-123-456-789"
        error={errors.badgeNumber?.message}
        {...register("badgeNumber")}
      />
      <Input
        label="Birth Date"
        type="date"
        error={errors.birthDate?.message}
        {...register("birthDate")}
      />
      <div className="flex justify-end gap-3 pt-2">
        <Button type="button" variant="secondary" onClick={onCancel}>
          Cancel
        </Button>
        <Button type="submit" isLoading={isSubmitting}>
          {isEditing ? "Update Officer" : "Create Officer"}
        </Button>
      </div>
    </form>
  );
}