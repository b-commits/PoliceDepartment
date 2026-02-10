import { describe, it, expect, vi } from "vitest";
import { render, screen } from "@testing-library/react";
import userEvent from "@testing-library/user-event";
import { OfficerForm } from "@/components/officers/OfficerForm";

describe("OfficerForm", () => {
  it("renders all form fields", () => {
    render(
      <OfficerForm
        onSubmit={vi.fn()}
        onCancel={vi.fn()}
        isSubmitting={false}
      />
    );

    expect(screen.getByLabelText("First Name")).toBeInTheDocument();
    expect(screen.getByLabelText("Last Name")).toBeInTheDocument();
    expect(screen.getByLabelText("Badge Number")).toBeInTheDocument();
    expect(screen.getByLabelText("Birth Date")).toBeInTheDocument();
  });

  it("shows 'Create Officer' button when no officer provided", () => {
    render(
      <OfficerForm
        onSubmit={vi.fn()}
        onCancel={vi.fn()}
        isSubmitting={false}
      />
    );

    expect(
      screen.getByRole("button", { name: "Create Officer" })
    ).toBeInTheDocument();
  });

  it("shows 'Update Officer' button when editing", () => {
    render(
      <OfficerForm
        officer={{
          id: "1",
          firstName: "John",
          lastName: "Smith",
          badgeNumber: { value: "#-123-456-789" },
          birthDate: { value: "1985-03-15" },
          created: "2024-01-01T00:00:00Z",
          modified: "2024-01-01T00:00:00Z",
        }}
        onSubmit={vi.fn()}
        onCancel={vi.fn()}
        isSubmitting={false}
      />
    );

    expect(
      screen.getByRole("button", { name: "Update Officer" })
    ).toBeInTheDocument();
  });

  it("calls onCancel when Cancel is clicked", async () => {
    const handleCancel = vi.fn();
    render(
      <OfficerForm
        onSubmit={vi.fn()}
        onCancel={handleCancel}
        isSubmitting={false}
      />
    );

    await userEvent.click(screen.getByRole("button", { name: "Cancel" }));

    expect(handleCancel).toHaveBeenCalledTimes(1);
  });

  it("shows validation errors for empty fields on submit", async () => {
    render(
      <OfficerForm
        onSubmit={vi.fn()}
        onCancel={vi.fn()}
        isSubmitting={false}
      />
    );

    await userEvent.click(
      screen.getByRole("button", { name: "Create Officer" })
    );

    expect(
      await screen.findByText("First name is required")
    ).toBeInTheDocument();
    expect(
      await screen.findByText("Last name is required")
    ).toBeInTheDocument();
  });

  it("shows validation error for invalid badge number", async () => {
    render(
      <OfficerForm
        onSubmit={vi.fn()}
        onCancel={vi.fn()}
        isSubmitting={false}
      />
    );

    await userEvent.type(screen.getByLabelText("First Name"), "John");
    await userEvent.type(screen.getByLabelText("Last Name"), "Doe");
    await userEvent.type(screen.getByLabelText("Badge Number"), "INVALID");
    await userEvent.type(screen.getByLabelText("Birth Date"), "1985-03-15");

    await userEvent.click(
      screen.getByRole("button", { name: "Create Officer" })
    );

    expect(
      await screen.findByText("Badge number must match format #-XXX-XXX-XXX")
    ).toBeInTheDocument();
  });
});