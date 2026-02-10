import type { Meta, StoryObj } from "@storybook/react";
import { DeleteOfficerDialog } from "@/components/officers/DeleteOfficerDialog";

const meta: Meta<typeof DeleteOfficerDialog> = {
  title: "Officers/DeleteOfficerDialog",
  component: DeleteOfficerDialog,
  tags: ["autodocs"],
  parameters: {
    layout: "centered",
  },
};

export default meta;

type Story = StoryObj<typeof DeleteOfficerDialog>;

export const Default: Story = {
  args: {
    isOpen: true,
    onClose: () => {},
    officer: {
      id: "1",
      firstName: "John",
      lastName: "Smith",
      badgeNumber: { value: "#-123-456-789" },
      birthDate: { value: "1985-03-15" },
      created: "2024-01-01T00:00:00Z",
      modified: "2024-01-01T00:00:00Z",
    },
    onConfirm: () => {},
    isDeleting: false,
  },
};

export const Deleting: Story = {
  args: {
    isOpen: true,
    onClose: () => {},
    officer: {
      id: "1",
      firstName: "John",
      lastName: "Smith",
      badgeNumber: { value: "#-123-456-789" },
      birthDate: { value: "1985-03-15" },
      created: "2024-01-01T00:00:00Z",
      modified: "2024-01-01T00:00:00Z",
    },
    onConfirm: () => {},
    isDeleting: true,
  },
};