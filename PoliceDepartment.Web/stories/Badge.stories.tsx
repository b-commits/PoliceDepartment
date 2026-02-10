import type { Meta, StoryObj } from "@storybook/react";
import { Badge } from "@/components/ui/Badge";

const meta: Meta<typeof Badge> = {
  title: "UI/Badge",
  component: Badge,
  tags: ["autodocs"],
  argTypes: {
    variant: {
      control: "select",
      options: ["default", "blue", "green", "red"],
    },
  },
};

export default meta;

type Story = StoryObj<typeof Badge>;

export const Default: Story = {
  args: { children: "Default", variant: "default" },
};

export const Blue: Story = {
  args: { children: "#-123-456-789", variant: "blue" },
};

export const Green: Story = {
  args: { children: "Active", variant: "green" },
};

export const Red: Story = {
  args: { children: "Inactive", variant: "red" },
};