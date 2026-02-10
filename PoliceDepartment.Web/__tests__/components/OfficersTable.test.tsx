import { describe, it, expect, vi } from "vitest";
import { render, screen } from "@testing-library/react";
import { OfficersTable } from "@/components/officers/OfficersTable";
import type { PoliceOfficer } from "@/types/officer";

const mockOfficers: PoliceOfficer[] = [
  {
    id: "1",
    firstName: "John",
    lastName: "Smith",
    badgeNumber: { value: "#-123-456-789" },
    birthDate: { value: "1985-03-15" },
    created: "2024-01-01T00:00:00Z",
    modified: "2024-01-01T00:00:00Z",
  },
  {
    id: "2",
    firstName: "Jane",
    lastName: "Doe",
    badgeNumber: { value: "#-987-654-321" },
    birthDate: { value: "1990-07-22" },
    created: "2024-01-02T00:00:00Z",
    modified: "2024-01-02T00:00:00Z",
  },
];

describe("OfficersTable", () => {
  it("renders column headers", () => {
    render(
      <OfficersTable data={mockOfficers} onEdit={vi.fn()} onDelete={vi.fn()} />
    );

    expect(screen.getByText("First Name")).toBeInTheDocument();
    expect(screen.getByText("Last Name")).toBeInTheDocument();
    expect(screen.getByText("Badge Number")).toBeInTheDocument();
    expect(screen.getByText("Birth Date")).toBeInTheDocument();
  });

  it("renders officer data rows", () => {
    render(
      <OfficersTable data={mockOfficers} onEdit={vi.fn()} onDelete={vi.fn()} />
    );

    expect(screen.getByText("John")).toBeInTheDocument();
    expect(screen.getByText("Smith")).toBeInTheDocument();
    expect(screen.getByText("#-123-456-789")).toBeInTheDocument();
    expect(screen.getByText("Jane")).toBeInTheDocument();
    expect(screen.getByText("Doe")).toBeInTheDocument();
  });

  it("shows empty state when no data", () => {
    render(
      <OfficersTable data={[]} onEdit={vi.fn()} onDelete={vi.fn()} />
    );

    expect(screen.getByText("No officers found.")).toBeInTheDocument();
  });

  it("renders search input", () => {
    render(
      <OfficersTable data={mockOfficers} onEdit={vi.fn()} onDelete={vi.fn()} />
    );

    expect(
      screen.getByPlaceholderText("Search officers...")
    ).toBeInTheDocument();
  });

  it("renders edit and delete buttons for each row", () => {
    render(
      <OfficersTable data={mockOfficers} onEdit={vi.fn()} onDelete={vi.fn()} />
    );

    expect(screen.getByLabelText("Edit John Smith")).toBeInTheDocument();
    expect(screen.getByLabelText("Delete John Smith")).toBeInTheDocument();
    expect(screen.getByLabelText("Edit Jane Doe")).toBeInTheDocument();
    expect(screen.getByLabelText("Delete Jane Doe")).toBeInTheDocument();
  });
});