import { describe, it, expect, vi } from "vitest";
import type { Mock } from "vitest";
import { render, screen } from "@testing-library/react";
import userEvent from "@testing-library/user-event";
import { DeleteOfficerDialog } from "@/components/officers/DeleteOfficerDialog";
import type { PoliceOfficer } from "@/types/officer";

const mockOfficer: PoliceOfficer = {
  id: "1",
  firstName: "John",
  lastName: "Smith",
  badgeNumber: { value: "#-123-456-789" },
  birthDate: { value: "1985-03-15" },
  created: "2024-01-01T00:00:00Z",
  modified: "2024-01-01T00:00:00Z",
};

describe("DeleteOfficerDialog", () => {
  it("shows officer name in confirmation message", () => {
    render(
      <DeleteOfficerDialog
        isOpen={true}
        onClose={vi.fn()}
        officer={mockOfficer}
        onConfirm={vi.fn()}
        isDeleting={false}
      />
    );

    expect(screen.getByText("John Smith")).toBeInTheDocument();
  });

  it("calls onConfirm when Delete is clicked", async () => {
    const handleConfirm: Mock = vi.fn();
    render(
      <DeleteOfficerDialog
        isOpen={true}
        onClose={vi.fn()}
        officer={mockOfficer}
        onConfirm={handleConfirm}
        isDeleting={false}
      />
    );

    await userEvent.click(screen.getByRole("button", { name: "Delete" }));

    expect(handleConfirm).toHaveBeenCalledTimes(1);
  });

  it("calls onClose when Cancel is clicked", async () => {
    const handleClose: Mock = vi.fn();
    render(
      <DeleteOfficerDialog
        isOpen={true}
        onClose={handleClose}
        officer={mockOfficer}
        onConfirm={vi.fn()}
        isDeleting={false}
      />
    );

    await userEvent.click(screen.getByRole("button", { name: "Cancel" }));

    expect(handleClose).toHaveBeenCalledTimes(1);
  });

  it("renders nothing when officer is null", () => {
    render(
      <DeleteOfficerDialog
        isOpen={true}
        onClose={vi.fn()}
        officer={null}
        onConfirm={vi.fn()}
        isDeleting={false}
      />
    );

    expect(screen.queryByText("Delete Officer")).not.toBeInTheDocument();
  });
});