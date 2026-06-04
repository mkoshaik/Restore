import { DarkMode, LightMode, ShoppingCart } from "@mui/icons-material";
import {
  AppBar,
  Badge,
  Box,
  IconButton,
  List,
  ListItem,
  Toolbar,
  Typography,
} from "@mui/material";
import { NavLink } from "react-router-dom";

const midLinks = [
  { title: "catalog", path: "/catalog" },
  { title: "about", path: "/about" },
  { title: "contact", path: "/contact" },
];
const rightLinks = [
  { title: "login", path: "/login" },
  { title: "register", path: "/register" },
];

const navStyles = {
  color: "inherit",
  typography: "h6",
  textDecoration: "none",
  "&:hover": {
    color: "grey.500",
  },
  "&.active": {
    color: "#baecf9",
  },
};

type NavBarProps = {
  toggleTheme: () => void;
  darkMode: boolean;
};
export default function NavBar({ toggleTheme, darkMode }: NavBarProps) {
  return (
    <AppBar position="fixed">
      <Toolbar
        sx={{
          display: "flex",
          justifyContent: "space-between",
          alignItems: "center",
        }}
      >
        <Box display={"flex"} alignItems={"center"}>
          <Typography component={NavLink} to={"/"} variant="h6" sx={navStyles}>
            RE-STORE
          </Typography>
          <IconButton onClick={toggleTheme}>
            {darkMode ? <DarkMode /> : <LightMode sx={{ color: "yellow" }} />}
          </IconButton>
        </Box>

        {/**List is a material UI Component */}
        <List sx={{ display: "flex" }}>
          {/**navbar links, note: ListItem is the material UI component */}
          {midLinks.map(({ title, path }) => (
            <ListItem
              component={NavLink /**NavLink is a react router component */}
              to={path}
              key={path}
              sx={navStyles}
            >
              {title.toUpperCase()}
            </ListItem>
          ))}
        </List>
        <Box display={"flex"} alignItems={"center"}>
          <IconButton size="large" sx={{ color: "inherit" }}>
            <Badge badgeContent="4" color="secondary">
              <ShoppingCart></ShoppingCart>
            </Badge>
          </IconButton>

          <List sx={{ display: "flex" }}>
            {/**navbar links, note: ListItem is the material UI component */}
            {rightLinks.map(({ title, path }) => (
              <ListItem
                component={NavLink /**NavLink is a react router component */}
                to={path}
                key={path}
                sx={navStyles}
              >
                {title.toUpperCase()}
              </ListItem>
            ))}
          </List>
        </Box>
      </Toolbar>
    </AppBar>
  );
}
