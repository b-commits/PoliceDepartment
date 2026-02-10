import type { Meta, StoryObj } from "@storybook/react";
import { OfficerForm } from "@/components/officers/OfficerForm";

const meta: Meta<typeof OfficerForm> = {
  title: "Officers/OfficerForm",
  component: OfficerForm,
  tags: ["autodocs"],
};

export default meta;

type Story = StoryObj<typeof OfficerForm>;

export const CreateMode: Story = {
  args: {
    onSubmit: () => {},
    onCancel: () => {},
    isSubmitting: false,
  },
};

export const EditMode: Story = {
  args: {
    officer: {
      id: "1",
      firstName: "John",
      lastName: "Smith",
      badgeNumber: { value: "#-123-456-789" },
      birthDate: { value: "1985-03-15" },
      created: "2024-01-01T00:00:00Z",
      modified: "2024-01-01T00:00:00Z",
    },
    onSubmit: () => {},
    onCancel: () => {},
    isSubmitting: false,
  },
};

export const Submitting: Story = {
  args: {
    onSubmit: () => {},
    onCancel: () => {},
    isSubmitting: true,
  },
};