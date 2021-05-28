import React, { useState } from "react";

import LinearProgress from "@material-ui/core/LinearProgress";
import {
  Box,
  Typography,
  Button,
  ListItem,
  withStyles,
} from "@material-ui/core";
import { useStyles } from "./upload-file.styles";

const BorderLinearProgress = withStyles((theme) => ({
  root: {
    height: 15,
    borderRadius: 5,
  },
  colorPrimary: {
    backgroundColor: "#EEEEEE",
  },
  bar: {
    borderRadius: 5,
    backgroundColor: "#1a90ff",
  },

  btnChoose: {
    marginBottom: theme.spacing(2),
  },
}))(LinearProgress);

interface UploadFileProps {
  setCurrentFile: any;
  currentFile: any;
}

const UploadFile = ({ currentFile, setCurrentFile }: UploadFileProps) => {
  const [selectedFiles, setSelectedFiles] = useState<any>();
  const [progress, setProgress] = useState(0);
  const [message, setMessage] = useState("");
  const [isError, setError] = useState(false);
  const [fileInfos, setFileInfos] = useState([]);

  const classes = useStyles();

  const selectFile = (e: any) => {
    setSelectedFiles(e.target.files);
  };

  const upload = (e: any) => {
    console.log("uploading");
    let currentFile = selectedFiles[0];
    console.log("selected:", selectedFiles[0]);
    console.log(currentFile);
    setProgress(0);
    setCurrentFile(currentFile);

    console.log(currentFile);
  };

  return (
    <div className="mg20">
      {currentFile && (
        <Box className="mb25" display="flex" alignItems="center">
          <Box width="100%" mr={1} mb={2}>
            <BorderLinearProgress variant="determinate" value={progress} />
          </Box>
          <Box minWidth={35}>
            <Typography
              variant="body2"
              color="textSecondary"
            >{`${progress}%`}</Typography>
          </Box>
        </Box>
      )}
      <label htmlFor="btn-upload">
        <input
          id="btn-upload"
          name="btn-upload"
          style={{ display: "none" }}
          type="file"
          onChange={selectFile}
        />
        <Button
          className={classes.btnChoose}
          variant="outlined"
          component="span"
        >
          Choose Files
        </Button>
        <Typography style={{ display: "inline-block" }}>Cover Photo</Typography>
      </label>
      <div className={classes.fileName}>
        {selectedFiles &&
        selectedFiles !== undefined &&
        selectedFiles?.length > 0
          ? selectedFiles[0].name
          : null}
      </div>
      <Button
        className="btn-upload"
        color="primary"
        variant="contained"
        component="span"
        disabled={!selectedFiles}
        onClick={(e: any) => upload(e)}
      >
        Upload
      </Button>
      <Typography
        variant="subtitle2"
        className={`upload-message ${isError ? "error" : ""}`}
      >
        {message}
      </Typography>
    </div>
  );
};

export { UploadFile };
