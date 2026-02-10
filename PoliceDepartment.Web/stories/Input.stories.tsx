import type { Meta, StoryObj } from "@storybook/react";
import { Input } from "@/components/ui/Input";

const meta: Meta<typeof Input> = {
  title: "UI/Input",
  component: Input,
  tags: ["autodocs"],
};

export default meta;

type Story = StoryObj<typeof Input>;

export const Default: Story = {
  args: { label: "First Name", placeholder: "Enter first name" },
};

export const WithError: Story = {
  args: {
    label: "Badge Number",
    placeholder: "#-XXX-XXX-XXX",
    error: "Badge number must match format #-XXX-XXX-XXX",
  },
};

export const Disabled: Story = {
  args: { label: "Email", placeholder: "email@example.com", disabled: true },
};

export const DateInput: Story = {
  args: { label: "Birth Date", type: "date" },
};