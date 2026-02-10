import type { Meta, StoryObj } from "@storybook/react";
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
  {
    id: "3",
    firstName: "Mike",
    lastName: "Johnson",
    badgeNumber: { value: "#-111-222-333" },
    birthDate: { value: "1978-11-05" },
    created: "2024-01-03T00:00:00Z",
    modified: "2024-01-03T00:00:00Z",
  },
];

const meta: Meta<typeof OfficersTable> = {
  title: "Officers/OfficersTable",
  component: OfficersTable,
  tags: ["autodocs"],
};

export default meta;

type Story = StoryObj<typeof OfficersTable>;

export const WithData: Story = {
  args: {
    data: mockOfficers,
    onEdit: () => {},
    onDelete: () => {},
  },
};

export const Empty: Story = {
  args: {
    data: [],
    onEdit: () => {},
    onDelete: () => {},
  },
};